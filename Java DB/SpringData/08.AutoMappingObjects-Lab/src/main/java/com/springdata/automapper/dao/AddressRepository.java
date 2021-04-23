package com.springdata.automapper.dao;

import com.springdata.automapper.entity.Address;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AddressRepository extends JpaRepository<Address, Long> {
}
