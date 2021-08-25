package demo.spring.vehicles.service;

import demo.spring.vehicles.model.entity.Brand;

import java.util.Collection;
import java.util.List;

public interface BrandService {
    Collection<Brand> getBrands();

    Brand getBrandById(String id);

    Brand createBrand(Brand post);

    Brand updateBrand(Brand post);

    Brand deleteBrand(String id);

    long getBrandsCount();

    List<Brand> createBrandsBatch(List<Brand> brandList);
}