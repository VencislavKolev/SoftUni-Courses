package com.springdata.gamestore.service;

import com.springdata.gamestore.domain.dto.AddGameDto;
import com.springdata.gamestore.domain.dto.EditGameDto;
import com.springdata.gamestore.domain.dto.GameDetailsDto;
import com.springdata.gamestore.domain.dto.GameDetailsFullDto;
import com.springdata.gamestore.domain.entity.Game;

import java.util.Set;

public interface GameService {
    String addGame(AddGameDto gameDto);

    String editGame(Long id, EditGameDto gameDto);

    String deleteGame(Long id);

    Game getGameById(Long id);

    Set<GameDetailsDto> getAllGames();

    GameDetailsFullDto getGameDetails(String title);

    Game findByTitle(String title);
}
