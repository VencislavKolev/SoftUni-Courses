package com.springdata.springintro.init;

import com.springdata.springintro.dao.PostRepository;
import com.springdata.springintro.entity.Post;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.Set;

@Component
public class DataInitializer implements CommandLineRunner {

    @Autowired
    PostRepository postRepo;

    @Override
    public void run(String... args) throws Exception {
        if (postRepo.count() == 0) {
            postRepo.saveAll(List.of(
                    new Post("Post1", "My first post", "Vencislav Kolev", Set.of("java","spring")),
                    new Post("Post2", "My second post", "Vencislav Kolev"),
                    new Post("Post3", "My third post", "Vencislav Kolev")
            ));
        }
    }
}
