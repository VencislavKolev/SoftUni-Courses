package com.springdata.springintro.web;

import com.springdata.springintro.dao.PostRepository;
import com.springdata.springintro.entity.Post;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.Collection;

@RestController
@RequestMapping(value = "/api/posts")
public class PostController {
    @Autowired
    private PostRepository postRepo;

    @GetMapping
    public Collection<Post> getAllPosts() {
        return this.postRepo.findAll();
    }

    @GetMapping(value = "/{id}")
    public Post getPostById(@PathVariable Long id) {
        return this.postRepo.findById(id).orElseThrow();
    }

    @PostMapping
    public Post addPost(@RequestBody Post post) {
        return this.postRepo.save(post);
    }

    @PutMapping(value = "/{postId}")
    public Post updatePost(@PathVariable Long postId, @RequestBody Post post) {
        this.deleteById(postId);
        return this.postRepo.save(post);
    }

    @DeleteMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.OK)
    public void deleteById(@PathVariable Long id) {
        this.postRepo.deleteById(id);
    }
}
