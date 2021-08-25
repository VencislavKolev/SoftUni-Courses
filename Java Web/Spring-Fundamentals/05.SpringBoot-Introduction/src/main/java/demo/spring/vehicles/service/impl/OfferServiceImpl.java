package demo.spring.vehicles.service.impl;

import demo.spring.vehicles.dao.OfferRepository;
import demo.spring.vehicles.model.entity.Offer;
import demo.spring.vehicles.model.entity.User;
import demo.spring.vehicles.service.OfferService;
import demo.spring.vehicles.service.UserService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.persistence.EntityNotFoundException;
import javax.validation.Valid;
import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

@Service
@Slf4j
public class OfferServiceImpl implements OfferService {

    private final OfferRepository offerRepo;
    private final UserService userService;
    //private final ApplicationEventPublisher applicationEventPublisher;

    @Autowired
    public OfferServiceImpl(OfferRepository offerRepo, UserService userService /*ApplicationEventPublisher applicationEventPublisher*/) {
        this.offerRepo = offerRepo;
        this.userService = userService;
       // this.applicationEventPublisher = applicationEventPublisher;
    }

    @Override
    public Collection<Offer> getOffers() {
        return this.offerRepo.findAll();
    }

    @Override
    public Offer getOfferById(String id) {
        return offerRepo.findById(id).orElseThrow(() ->
                new EntityNotFoundException(String.format("Offer with ID=%s not found.", id)));
    }

    @Override
    public Offer createOffer(@Valid Offer offer) {
        String sellerId;

        if (offer.getSeller() != null && offer.getSeller().getId() != null) {
            sellerId = offer.getSeller().getId();
        } else {
            sellerId = offer.getSellerId();
        }

        if (sellerId != null) {
            User seller = this.userService.getUserById(sellerId);
            offer.setSeller(seller);
        }

        if (offer.getCreatedOn() == null) {
            offer.setCreatedOn(new Date());
        }
        offer.setModifiedOn(offer.getCreatedOn());

        return this.offerRepo.save(offer);
    }

    @Override
    public Offer updateOffer(Offer offer) {
        offer.setModifiedOn(new Date());
        Offer toUpdate = this.getOfferById(offer.getId());

        if (offer.getSeller() != null && !offer.getSeller().getId().equals(toUpdate.getSeller().getId())) {
            throw new IllegalArgumentException("Seller of article could not be changed");
        }
        offer.setSeller(toUpdate.getSeller());

        return this.offerRepo.save(offer);
    }

    @Override
    public Offer deleteOffer(String id) {
        Offer toDelete = this.getOfferById(id);
        this.offerRepo.deleteById(id);
        return toDelete;
    }

    @Override
    public long getOffersCount() {
        return this.offerRepo.count();
    }

    @Override
    public List<Offer> createOffersBatch(List<Offer> offers) {
        List<Offer> created = offers.stream()
                .map(offer -> {
                    Offer resultOffer = createOffer(offer);
                    //applicationEventPublisher.publishEvent(new OfferCreationEvent(resultOffer));
                    return resultOffer;
                }).collect(Collectors.toList());
        return created;
    }

//    @TransactionalEventListener
//    public void handleOfferCreatedTransactionCommit(OfferCreationEvent creationEvent) {
//        log.info(">>> Transaction COMMIT for article: {}", creationEvent.getOffer());
//    }
//
//    @TransactionalEventListener(phase = TransactionPhase.AFTER_ROLLBACK)
//    public void handleOfferCreatedTransactionRollback(OfferCreationEvent creationEvent) {
//        log.info(">>> Transaction ROLLBACK for article: {}", creationEvent.getOffer());
//    }

}
