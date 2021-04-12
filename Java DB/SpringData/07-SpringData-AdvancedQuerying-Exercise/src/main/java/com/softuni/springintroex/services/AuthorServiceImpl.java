package com.softuni.springintroex.services;

import com.softuni.springintroex.constants.GlobalConstants;
import com.softuni.springintroex.domain.entities.Author;
import com.softuni.springintroex.domain.repositories.AuthorRepository;
import com.softuni.springintroex.utils.FileUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;

@Service
public class AuthorServiceImpl implements AuthorService {
    private final AuthorRepository authorRepo;
    private final FileUtil fileUtil;

    @Autowired
    public AuthorServiceImpl(AuthorRepository authorRepo, FileUtil fileUtil) {
        this.authorRepo = authorRepo;
        this.fileUtil = fileUtil;
    }

    @Override
    public void seedAuthorsInDB() throws IOException {
        var content = this.fileUtil.readFileContent(GlobalConstants.AUTHORS_FILE_PATH);

        for (String line : content) {
            String firstName = line.split(" ")[0];
            String lastName = line.split(" ")[1];
            Author author = new Author(firstName, lastName);
            this.authorRepo.saveAndFlush(author);
        }
    }
}
