package com.softuni.springintroex.services;

import com.softuni.springintroex.constants.GlobalConstants;
import com.softuni.springintroex.domain.entities.Author;
import com.softuni.springintroex.domain.entities.Book;
import com.softuni.springintroex.domain.repositories.AuthorRepository;
import com.softuni.springintroex.utils.FileUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

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

    @Override
    public void printAuthorWithFirstNameEndingWith(String pattern) {
        this.authorRepo.findAllByFirstNameEndingWith(pattern)
                .forEach(a -> System.out.printf("%s %s%n",
                        a.getFirstName(), a.getLastName()));
    }

    @Override
    public void printAuthorsByBookCopies() {
        List<Author> authors = this.authorRepo.findAll();
        Map<String, Integer> authorCopies = new HashMap<>();

        for (Author a : authors) {
            int copies = a.getBooks()
                    .stream()
                    .mapToInt(Book::getCopies)
                    .sum();
            String fullName = a.getFirstName() + " " + a.getLastName();
            authorCopies.put(fullName, copies);
        }

        authorCopies.entrySet()
                .stream()
                .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
                //.sorted((first, second) -> Integer.compare(second.getValue(), first.getValue()))
                .forEach(System.out::println);
    }
}
