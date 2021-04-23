package com.springdata.automapper.service.impl;

import com.springdata.automapper.dao.AddressRepository;
import com.springdata.automapper.entity.Address;
import com.springdata.automapper.service.AddressService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.NoSuchElementException;

@Service
@Transactional(readOnly = true)
public class AddressServiceImpl implements AddressService {

    private final AddressRepository addressRepo;

    @Autowired
    public AddressServiceImpl(AddressRepository addressRepo) {
        this.addressRepo = addressRepo;
    }

    @Override
    public List<Address> getAllAddreses() {
        return this.addressRepo.findAll();
    }

    @Override
    public Address getAddressById(Long id) {
        return this.addressRepo.findById(id)
                .orElseThrow(() -> new NoSuchElementException(
                        String.format("Address with ID: %s does not exist", id)
                ));
    }

    @Override
    @Transactional
    public Address addAddress(Address address) {
        address.setId(null);
        return this.addressRepo.save(address);
    }

    @Override
    @Transactional
    public Address updateAddress(Address address) {
        this.getAddressById(address.getId());
        return this.addressRepo.save(address);
    }

    @Override
    @Transactional
    public Address deleteAddress(Long id) {
        Address address = this.getAddressById(id);
        this.addressRepo.delete(address);
        return address;
    }

    @Override
    public long getAddressCount() {
        return this.addressRepo.count();
    }
}
