package com.citi.service;

import java.util.Optional;

import com.citi.dto.CartItemDTO;
import com.citi.dto.ItemDTO;
import com.citi.entity.CartItem;

public interface CartService {
	 public void addItemToCard(CartItemDTO cartItem);
	 public void removeItemFromCard(Integer itemCode, String username);
	Optional<CartItem> viewCart(Integer itemCode);

}
