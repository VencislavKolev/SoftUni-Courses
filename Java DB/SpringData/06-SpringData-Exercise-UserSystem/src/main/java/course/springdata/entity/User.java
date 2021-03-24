package course.springdata.entity;

import course.springdata.util.Password;

import javax.persistence.*;
import javax.validation.constraints.Email;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.Size;
import java.time.LocalDateTime;
import java.util.HashSet;
import java.util.Set;

import static course.springdata.constants.GlobalConstants.*;

@Entity
@Table(name = "users")
public class User extends BaseEntity {

    private String username;
    private String password;
    private String email;
    private LocalDateTime registeredOn;
    private LocalDateTime lastTimeLoggedIn;
    private int age;
    private boolean isDeleted;

    private String firstName;
    private String lastName;
    private String fullName;

    private Set<User> colleagues;
    private Set<User> teammates;

    public User() {
        this.colleagues = new HashSet<>();
        this.teammates = new HashSet<>();
        this.registeredOn = LocalDateTime.now();
    }

    public User(String username, String password, String email, int age) {
        this();
        this.username = username;
        this.password = password;
        this.email = email;
        this.age = age;
    }

    public User(String username, String password, String email, int age, String firstName, String lastName) {
        this(username, password, email, age);

        this.firstName = firstName;
        this.lastName = lastName;
    }

    @Column(name = "username", nullable = false)
    @NotEmpty
    @Size(min = 4, max = 30, message = USERNAME_CONSTRAINT)
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    @Column(nullable = false)
    @Password
    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Email
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Column(name = "registered_on")
    public LocalDateTime getRegisteredOn() {
        return registeredOn;
    }

    public void setRegisteredOn(LocalDateTime registeredOn) {
        this.registeredOn = registeredOn;
    }

    @Column(name = "last_time_logged_in")
    public LocalDateTime getLastTimeLoggedIn() {
        return lastTimeLoggedIn;
    }

    public void setLastTimeLoggedIn(LocalDateTime lastTimeLoggedIn) {
        this.lastTimeLoggedIn = lastTimeLoggedIn;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Column(name = "is_deleted")
    public boolean isDeleted() {
        return isDeleted;
    }

    public void setDeleted(boolean deleted) {
        isDeleted = deleted;
    }

    @Column(name = "first_name")
    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    @Column(name = "last_name")
    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    @Transient
    public String getFullName() {
        return String.format("%s %s",
                this.getFirstName(),
                this.getLastName());
    }

    @ManyToMany(cascade = CascadeType.ALL,fetch = FetchType.EAGER)
    @JoinTable(name = "colleagues_teammates",
            joinColumns = @JoinColumn(name = "employee_id"),
            inverseJoinColumns = @JoinColumn(name = "teammate_id"))
    public Set<User> getColleagues() {
        return colleagues;
    }

    public void setColleagues(Set<User> colleagues) {
        this.colleagues = colleagues;
    }

    @ManyToMany(mappedBy = "colleagues")
    public Set<User> getTeammates() {
        return teammates;
    }

    public void setTeammates(Set<User> teammates) {
        this.teammates = teammates;
    }

    @Override
    public String toString() {
        return "User{" +
                "username='" + username + '\'' +
                ", email='" + email + '\'' +
                ", age=" + age +
                ", fullName='" + this.getFullName() + '\'' +
                '}';
    }
}
