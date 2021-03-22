package course.springdata.init;

import course.springdata.entity.Account;
import course.springdata.entity.User;
import course.springdata.exception.InvalidAccountOperationException;
import course.springdata.exception.NonExistingEntityException;
import course.springdata.service.AccountService;
import course.springdata.service.UserService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.math.BigDecimal;

@Component
@Slf4j
public class ConsoleRunner implements CommandLineRunner {

    private final AccountService accountService;
    private final UserService userService;

    @Autowired
    public ConsoleRunner(AccountService accountService, UserService userService) {
        this.accountService = accountService;
        this.userService = userService;
    }

    @Override
    public void run(String... args) {

        //-------------Withdraw-------------

        User user1 = new User("Vencislav Kolev", 23);
        Account user1Account = new Account(new BigDecimal(2000));

        this.userService.registerUser(user1);
        this.accountService.createUserAccount(user1, user1Account);

        try {
            this.accountService.withdrawMoney(new BigDecimal(1000), user1Account.getId());
        } catch (NonExistingEntityException | InvalidAccountOperationException ex) {
            log.error(String.format("Error executing operation for account: %s - %s",
                    user1Account, ex.getMessage()));
        }

        this.accountService.getAllAccounts()
                .forEach(System.out::println); //1000

        //-------------Deposit-------------

        User user2 = new User("Ivan Ivanov", 40);
        Account user2Account = new Account(new BigDecimal(2500));

        this.userService.registerUser(user2);
        this.accountService.createUserAccount(user2, user2Account);

        try {
            this.accountService.depositMoney(new BigDecimal(1000), user2Account.getId());
        } catch (NonExistingEntityException | InvalidAccountOperationException ex) {
            log.error(String.format("Error executing operation for account: %s - %s",
                    user2Account, ex.getMessage()));
        }

        this.accountService.getAllAccounts()
                .forEach(System.out::println); //3500

        //-------------Transfer-------------

        try {
            accountService.transferMoney(
                    new BigDecimal(1000),
                    user1Account.getId(),
                    user2Account.getId());
        } catch (NonExistingEntityException | InvalidAccountOperationException ex) {
            log.error(String.format("Error executing operation for account: %s - %s",
                    user2Account, ex.getMessage()));
        }

        accountService.getAllAccounts().forEach(System.out::println);
    }
}
