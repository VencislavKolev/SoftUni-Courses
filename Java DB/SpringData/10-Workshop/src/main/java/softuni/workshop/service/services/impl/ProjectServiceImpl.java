package softuni.workshop.service.services.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import softuni.workshop.data.repositories.ProjectRepository;
import softuni.workshop.service.services.ProjectService;


@Service
public class ProjectServiceImpl implements ProjectService {

    private final ProjectRepository projectRepo;

    @Autowired
    public ProjectServiceImpl(ProjectRepository projectRepo) {
        this.projectRepo = projectRepo;
    }

    @Override
    public void importProjects() {
        //TODO seed in database
    }

    @Override
    public boolean areImported() {
        return this.projectRepo.count() > 0;
    }

    @Override
    public String readProjectsXmlFile() {
        //TODO read xml file
        return null;
    }

    @Override
    public String exportFinishedProjects() {
        //TODO export finished projects
        return null;
    }
}
