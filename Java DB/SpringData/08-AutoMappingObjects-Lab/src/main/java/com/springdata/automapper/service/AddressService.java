package com.springdata.automapper.service;

import com.springdata.automapper.entity.Address;

import java.util.List;

public interface AddressService {
    List<Address> getAllAddreses();

    Address getAddressById(Long id);

    Address addAddress(Address address);

    Address updateAddress(Address address);

    Address deleteAddress(Long id);

    long getAddressCount();
}
