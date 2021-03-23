package course.springdata.service;

import course.springdata.entity.Author;
import course.springdata.repository.AuthorRepository;
import course.springdata.utils.FileUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

import static course.springdata.constants.GlobalConstants.*;

@Service
public class AuthorServiceImpl implements AuthorService {

    private final FileUtil fileUtil;
    private final AuthorRepository authorRepo;

    @Autowired
    public AuthorServiceImpl(FileUtil fileUtil, AuthorRepository authorRepo) {
        this.fileUtil = fileUtil;
        this.authorRepo = authorRepo;
    }

    @Override
    public void seedAuthors() throws IOException {
        if (this.authorRepo.count() != 0) {
            return;
        }

        String[] fileContent = this.fileUtil
                .readFileContent(AUTHORS_FILE_PATH);

        Arrays.stream(fileContent)
                .forEach(line -> {
                    String[] tokens = line.split("\\s+");
                    Author author = new Author(tokens[0], tokens[1]);
                    this.authorRepo.saveAndFlush(author);
                });

    }

    @Override
    public int getTotalAuthorsCount() {
        return (int) this.authorRepo.count();
    }

    @Override
    public Author getAuthorById(Long id) {
        return this.authorRepo.getOne(id);
    }

    @Override
    public List<Author> getAuthorsOrderedByBooksCountDescending() {
        return this.authorRepo.getAuthorsByBooksDesc();
    }
}
