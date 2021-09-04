package demo.spring.vehicles.dao;

import demo.spring.vehicles.model.entity.Offer;
import org.springframework.data.jpa.repository.JpaRepository;

public interface OfferRepository extends JpaRepository<Offer, String> {
}
