package demo.spring.vehicles.service.impl;

import demo.spring.vehicles.dao.BrandRepository;
import demo.spring.vehicles.model.entity.Brand;
import demo.spring.vehicles.service.BrandService;
import lombok.AllArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import javax.validation.Valid;
import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class BrandServiceImpl implements BrandService {

    private final BrandRepository brandRepo;

    @Autowired
    public BrandServiceImpl(BrandRepository brandRepo) {
        this.brandRepo = brandRepo;
    }

    @Override
    public Collection<Brand> getBrands() {
        return this.brandRepo.findAll();
    }

    @Override
    public Brand getBrandById(String id) {
        return this.brandRepo.findById(id)
                .orElseThrow(() -> new EntityNotFoundException(String.format("Brand with ID= %s not found", id)));
    }

    @Override
    public Brand createBrand(@Valid Brand brand) {
        if (brand.getCreatedOn() == null) {
            brand.setCreatedOn(new Date());
        }
        brand.setModifiedOn(brand.getCreatedOn());
        return brandRepo.save(brand);
    }

    @Override
    public Brand updateBrand(Brand brand) {
        brand.setModifiedOn(new Date());
        Brand old = this.getBrandById(brand.getId());
        return this.brandRepo.save(brand);
    }

    @Override
    public Brand deleteBrand(String id) {
        Brand toDelete = this.getBrandById(id);
        this.brandRepo.deleteById(id);
        return toDelete;
    }

    @Override
    public long getBrandsCount() {
        return this.brandRepo.count();
    }

    @Transactional
    @Override
    public List<Brand> createBrandsBatch(List<Brand> brandList) {
        List<Brand> created = brandList.stream()
                .map(brand -> {
                    Brand createdBrand = createBrand(brand);
                    return createdBrand;
                }).collect(Collectors.toList());
        return created;
    }
}
