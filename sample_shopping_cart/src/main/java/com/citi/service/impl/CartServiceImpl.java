package com.citi.service.impl;
import java.util.Optional;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.server.ResponseStatusException;

import com.citi.dto.CartItemDTO;
import com.citi.dto.ItemDTO;
import com.citi.entity.CartItem;
import com.citi.entity.Item;
import com.citi.repository.CartItemRepository;
import com.citi.repository.ItemRepository;
import com.citi.service.CartService;

@Service
public class CartServiceImpl implements CartService {

    private CartItemRepository cartItemRepository;
    private RestTemplate restTemplate;
	private ItemRepository itemRepository;

    public CartServiceImpl(CartItemRepository cartItemRepository, RestTemplate restTemplate) {
        this.cartItemRepository = cartItemRepository;
        this.restTemplate = restTemplate;
    }

    @Override
    public void addItemToCard(CartItemDTO cartItem) {
    	// adding a custom business logic where we do not validate the availability in the inventory of the item
    	//ItemDTO itemInStock = restTemplate.getForObject("http://INVENTORY-SERVICE/api/v1/items/{code}", ItemDTO.class, cartItem.getItemCode());
        
        Optional<CartItem> optCartItem = cartItemRepository.findCartItemByItemCodeAndUsername(cartItem.getItemCode(), cartItem.getUsername());
        System.out.println(optCartItem + " "+ optCartItem.toString());

        //if (optCartItem.isEmpty()){
          //  if (itemInStock.getQty() < cartItem.getQty()) throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Insufficient stock!");
            cartItemRepository.save(new CartItem(cartItem.getUsername(), cartItem.getItemCode(), cartItem.getQty()));
			/*
			 * //}else{ CartItem cartItemEntity = optCartItem.get(); //if
			 * (itemInStock.getQty() < (cartItem.getQty() + cartItemEntity.getQty()))throw
			 * new ResponseStatusException(HttpStatus.BAD_REQUEST, "Insufficient stock!");
			 * cartItemEntity.setQty(cartItemEntity.getQty() + cartItem.getQty());
			 * cartItemRepository.save(cartItemEntity); //}
			 */
    }

    @Override
    public void removeItemFromCard(Integer itemCode, String username) {
        CartItem cartItem = cartItemRepository.findCartItemByItemCodeAndUsername(itemCode, username).orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Cart item doesn't exist"));
        cartItemRepository.delete(cartItem);
    }
    
   
    @Override
    public Optional<CartItem> viewCart(Integer itemCode) {
    	return this.cartItemRepository.findCartItemByItemCodeAndUsername(itemCode, "Test1234");
        
    }
}