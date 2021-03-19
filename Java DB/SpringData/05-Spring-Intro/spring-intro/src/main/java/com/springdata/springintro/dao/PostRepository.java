package com.springdata.springintro.dao;

import com.springdata.springintro.entity.Post;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PostRepository extends JpaRepository<Post, Long> {
}
