package course.springdata.entity;

import javax.persistence.*;

@Entity
@Table(name = "towns")
public class Town extends BaseEntity {
    private String name;
    private Country country;

    public Town() {
    }

    public Town(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @ManyToOne()
    //@JoinColumn(name = "country_id", referencedColumnName = "id")
    public Country getCountry() {
        return country;
    }

    public void setCountry(Country country) {
        this.country = country;
    }
}
