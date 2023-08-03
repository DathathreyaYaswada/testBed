package com.citi.shopping.controller;

import com.citi.dto.CartItemDTO;
import com.citi.dto.ItemDTO;
import com.citi.entity.CartItem;
import com.citi.entity.Item;
import com.citi.service.CartService;
import com.citi.service.ItemService;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.nio.charset.StandardCharsets;
import java.util.Base64;
import java.util.Optional;

@RestController
@CrossOrigin
@RequestMapping("/api/v1/cart-items")
public class CartController {

    private CartService cartService;
	private ItemService itemService;
	private Item item;

    public CartController(CartService cartService, ItemService itemService) {
        this.cartService = cartService;
        this.itemService = itemService;
    }

    private String getPrincipal(String authorizationToken){
        String token = authorizationToken.replaceAll("Basic ", "");
        String loginCredentials = new String(Base64.getDecoder().decode(token), StandardCharsets.UTF_8);
        return loginCredentials.split(":")[0];
    }

    @ResponseStatus(HttpStatus.CREATED)
    @PostMapping(value="/addToCart", consumes = "application/json")
    public void addNewItemToCard(@RequestBody CartItemDTO cartItem, @RequestHeader String authorization){
        cartItem.setUsername(getPrincipal(authorization));
        this.cartService.addItemToCard(cartItem);
    }
    
    @GetMapping("/viewCart/{code:\\d+}")
    public Optional<CartItem> viewCart(@PathVariable Integer code){
        return this.cartService.viewCart(code);
    }

    @ResponseStatus(HttpStatus.NO_CONTENT)
    @DeleteMapping("/{code:\\d+}")
    public void removeItemFromCard(@PathVariable Integer code, @RequestHeader String authorization){
        this.cartService.removeItemFromCard(code, getPrincipal(authorization));
    }
    
    @GetMapping("/{code:\\d+}")
    public ItemDTO getItem(@PathVariable Integer code){
        return this.itemService.getItem(code);
    }
    
    
    @ResponseStatus(HttpStatus.CREATED)
    @PostMapping(value="/addItem", consumes = "application/json")
    public ItemDTO addNewItemToInventory(@RequestBody ItemDTO item){
    	 return this.itemService.addNewItem(item);
    }
}