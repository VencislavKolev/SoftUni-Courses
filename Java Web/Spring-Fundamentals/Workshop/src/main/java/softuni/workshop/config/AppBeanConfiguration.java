package softuni.workshop.config;

import org.modelmapper.ModelMapper;
import org.springframework.context.annotation.Configuration;

@Configuration
public class AppBeanConfiguration {
    public ModelMapper modelMapper(){
        return new ModelMapper();
    }
}