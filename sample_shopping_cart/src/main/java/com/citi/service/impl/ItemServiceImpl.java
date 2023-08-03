package com.citi.service.impl;

import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import com.citi.dto.ItemDTO;
import com.citi.entity.Item;
import com.citi.repository.ItemRepository;
import com.citi.service.ItemService;

@Service
public class ItemServiceImpl implements ItemService {

    private ItemRepository itemRepository;

    public ItemServiceImpl(ItemRepository itemRepository) {
        this.itemRepository = itemRepository;
    }

    @Override
    public ItemDTO addNewItem(ItemDTO item) {
        Item entity = this.itemRepository.save(new Item( item.getDescription(), item.getQty()));
        return new ItemDTO(entity.getCode(), entity.getDescription(), entity.getQty());
    }

    @Override
    public ItemDTO getItem(Integer code) {
        return this.itemRepository.findById(code).map(entity -> new ItemDTO(entity.getCode(), entity.getDescription(), entity.getQty()))
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND));
    }
}
