package com.springdata.gamestore.service;

import com.springdata.gamestore.domain.dto.AddGameDto;
import com.springdata.gamestore.domain.dto.EditGameDto;
import com.springdata.gamestore.domain.entity.Game;

public interface GameService {
    String addGame(AddGameDto gameDto);

    String editGame(Long id, EditGameDto gameDto);

    String deleteGame(Long id);

    Game getGameById(Long id);
}
