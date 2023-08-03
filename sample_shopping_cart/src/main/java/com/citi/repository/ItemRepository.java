package com.citi.repository;

import org.springframework.data.repository.CrudRepository;

import com.citi.entity.Item;

public interface ItemRepository extends CrudRepository<Item, Integer> {
}
