package com.springdata.gamestore.repository;

import com.springdata.gamestore.domain.entity.Game;
import org.springframework.data.jpa.repository.JpaRepository;

public interface GameRepository extends JpaRepository<Game, Long> {
}
