package demo.spring.vehicles.dao;

import demo.spring.vehicles.model.entity.Brand;
import org.springframework.data.jpa.repository.JpaRepository;

public interface BrandRepository extends JpaRepository<Brand, String> {
}
