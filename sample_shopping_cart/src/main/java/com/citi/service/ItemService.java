package com.citi.service;

import com.citi.dto.ItemDTO;

public interface ItemService {

	ItemDTO addNewItem(ItemDTO item);

	ItemDTO getItem(Integer code);

}
