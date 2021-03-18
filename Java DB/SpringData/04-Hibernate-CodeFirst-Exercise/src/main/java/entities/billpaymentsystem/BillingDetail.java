package entities.billpaymentsystem;

import entities.BaseEntity;

import javax.persistence.*;

@Entity
@Inheritance(strategy = InheritanceType.JOINED)
@Table(name = "billing_details")
public abstract class BillingDetail extends BaseEntity {

    private String billingDetail;
    private User owner;

    public BillingDetail() {
    }

    @Column(name = "billing_detail")
    public String getBillingDetail() {
        return billingDetail;
    }

    public void setBillingDetail(String name) {
        this.billingDetail = name;
    }

    @ManyToOne
    @JoinColumn(name = "owner_id", referencedColumnName = "id")
    public User getOwner() {
        return owner;
    }

    public void setOwner(User owner) {
        this.owner = owner;
    }
}
