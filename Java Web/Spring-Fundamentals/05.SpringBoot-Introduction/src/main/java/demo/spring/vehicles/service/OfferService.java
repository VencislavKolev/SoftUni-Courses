package demo.spring.vehicles.service;

import demo.spring.vehicles.model.entity.Offer;

import java.util.Collection;
import java.util.List;

public interface OfferService {
    Collection<Offer> getOffers();

    Offer getOfferById(String id);

    Offer createOffer(Offer offer);

    Offer updateOffer(Offer offer);

    Offer deleteOffer(String id);

    long getOffersCount();

    List<Offer> createOffersBatch(List<Offer> offers);
}