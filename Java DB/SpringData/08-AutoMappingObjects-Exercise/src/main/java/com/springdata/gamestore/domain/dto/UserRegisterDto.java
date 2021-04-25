package com.springdata.gamestore.domain.dto;

import com.springdata.gamestore.util.FieldMatch;
import com.springdata.gamestore.util.Password;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.validation.constraints.Email;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@FieldMatch(first = "password", second = "confirmPassword", message = "The password fields must match")
public class UserRegisterDto {
    @Email
    private String email;
    @Password
    private String password;
    private String confirmPassword;
    private String fullName;
}
