package com.citi.repository;

import org.springframework.data.repository.CrudRepository;

import com.citi.entity.CartItem;

import java.util.Optional;

public interface CartItemRepository extends CrudRepository<CartItem, String> {
	Optional<CartItem> findCartItemByItemCodeAndUsername(Integer itemCode, String username);
	
}
