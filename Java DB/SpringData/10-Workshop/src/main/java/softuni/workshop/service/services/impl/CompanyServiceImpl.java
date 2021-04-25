package softuni.workshop.service.services.impl;

import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import softuni.workshop.data.entities.Company;
import softuni.workshop.data.repositories.CompanyRepository;
import softuni.workshop.service.dto.CompanyDto;
import softuni.workshop.service.dto.CompanyRootDto;
import softuni.workshop.service.services.CompanyService;
import softuni.workshop.util.XmlParser;

import javax.xml.bind.JAXBException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

@Service
public class CompanyServiceImpl implements CompanyService {

    private static final String COMPANIES_PATH = "src/main/resources/files/xmls/companies.xml";
    private final CompanyRepository companyRepo;
    private final XmlParser xmlParser;
    private final ModelMapper modelMapper;

    @Autowired
    public CompanyServiceImpl(CompanyRepository companyRepo, XmlParser xmlParser, ModelMapper modelMapper) {
        this.companyRepo = companyRepo;
        this.xmlParser = xmlParser;
        this.modelMapper = modelMapper;
    }

    @Override
    public void importCompanies() throws JAXBException {
        CompanyRootDto companyRootDto = this.xmlParser.importXMl(CompanyRootDto.class, COMPANIES_PATH);
        for (CompanyDto companyDto : companyRootDto.getCompanyDtoList()) {
            this.companyRepo.save(this.modelMapper.map(companyDto, Company.class));
        }
    }

    @Override
    public boolean areImported() {
        return this.companyRepo.count() > 0;
    }

    @Override
    public String readCompaniesXmlFile() throws IOException {
        return String.join(System.lineSeparator(), Files.readAllLines(Path.of(COMPANIES_PATH)));
    }
}
