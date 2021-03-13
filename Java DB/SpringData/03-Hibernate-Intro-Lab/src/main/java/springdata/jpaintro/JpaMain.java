package springdata.jpaintro;

import springdata.jpaintro.entity.Student;
import springdata.jpaintro.entity.StudentLombok;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class JpaMain {
    public static void main(String[] args) {

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("school_jpa");
        EntityManager em = emf.createEntityManager();


        Student student = new Student("Vencislav Kolev");
//        em.getTransaction().begin();
//        em.persist(student);
//        em.getTransaction().commit();

        StudentLombok studentLombok = new StudentLombok("Vencislav Kolev");
        em.getTransaction().begin();
        em.persist(studentLombok);
        em.getTransaction().commit();

        em.getTransaction().begin();
        var toFind = em.find(StudentLombok.class, 1L);
        System.out.printf("Found student: %s%n", toFind.toString());
        em.getTransaction().commit();


        em.close();
    }
}
