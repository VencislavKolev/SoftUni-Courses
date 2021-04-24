package com.springdata.gamestore.service.impl;

import com.springdata.gamestore.domain.dto.AddGameDto;
import com.springdata.gamestore.domain.dto.EditGameDto;
import com.springdata.gamestore.domain.dto.GameDetailsDto;
import com.springdata.gamestore.domain.dto.GameDetailsFullDto;
import com.springdata.gamestore.domain.entity.Game;
import com.springdata.gamestore.repository.GameRepository;
import com.springdata.gamestore.service.GameService;
import com.springdata.gamestore.util.ValidatorUtil;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.NoSuchElementException;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class GameServiceImpl implements GameService {
    private static final StringBuilder sb = new StringBuilder();
    private final ValidatorUtil validatorUtil;
    private final ModelMapper modelMapper;
    private final GameRepository gameRepo;

    @Autowired
    public GameServiceImpl(ValidatorUtil validatorUtil, ModelMapper modelMapper, GameRepository gameRepo) {
        this.validatorUtil = validatorUtil;
        this.modelMapper = modelMapper;
        this.gameRepo = gameRepo;
    }


    @Override
    public String addGame(AddGameDto gameDto) {

        if (this.validatorUtil.isValid(gameDto)) {
            Game game = this.modelMapper.map(gameDto, Game.class);
            this.gameRepo.save(game);
            sb.append("Added " + gameDto.getTitle());
        } else {
            this.validatorUtil.violations(gameDto)
                    .forEach(e -> sb.append(String.format("%s%n", e.getMessage())));
        }

        return sb.toString().trim();
    }

    @Override
    public String editGame(Long id, EditGameDto gameDto) {
        Game existing = this.getGameById(id);
        if (this.validatorUtil.isValid(gameDto)) {
            existing.setPrice(gameDto.getPrice());
            existing.setSize(gameDto.getSize());
        } else {
            this.validatorUtil.violations(gameDto)
                    .forEach(e -> sb.append(String.format("%s%n", e.getMessage())));
        }
        this.gameRepo.save(existing);

        sb.append("Edited " + existing.getTitle());
        return sb.toString();
    }

    @Override
    public String deleteGame(Long id) {
        Game toDelete = this.getGameById(id);
        this.gameRepo.delete(toDelete);
        sb.append("Deleted " + toDelete.getTitle());
        return sb.toString();
    }

    @Override
    public Game getGameById(Long id) {
        return this.gameRepo.findById(id)
                .orElseThrow(() -> new NoSuchElementException(
                        String.format("Game with ID: %s does not exist", id)
                ));
    }

    @Override
    public Set<GameDetailsDto> getAllGames() {
        Set<GameDetailsDto> games = this.gameRepo.findAll()
                .stream()
                .map(game -> this.modelMapper.map(game, GameDetailsDto.class))
                .collect(Collectors.toSet());
        return games;
    }

    @Override
    public GameDetailsFullDto getGameDetails(String title) {
        Game game = this.gameRepo.findByTitle(title)
                .orElseThrow(() -> new NoSuchElementException("No such game"));
        GameDetailsFullDto gameDetails = this.modelMapper.map(game, GameDetailsFullDto.class);
        return gameDetails;

    }
}
