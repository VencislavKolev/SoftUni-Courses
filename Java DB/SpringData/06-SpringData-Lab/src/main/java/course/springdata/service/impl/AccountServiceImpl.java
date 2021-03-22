package course.springdata.service.impl;

import course.springdata.dao.AccountRepository;
import course.springdata.entity.Account;
import course.springdata.entity.User;
import course.springdata.exception.InvalidAccountOperationException;
import course.springdata.exception.NonExistingEntityException;
import course.springdata.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import java.math.BigDecimal;
import java.util.List;

@Service
@Transactional(propagation = Propagation.REQUIRED)
public class AccountServiceImpl implements AccountService {
    private AccountRepository accountRepo;

    @Autowired
    public void setAccountRepo(AccountRepository accountRepo) {
        this.accountRepo = accountRepo;
    }

    @Override
    public Account createUserAccount(User user, Account account) {
        account.setId(null);
        account.setUser(user);
        user.getAccounts().add(account);
        return accountRepo.save(account);
    }

    @Override
    public void withdrawMoney(BigDecimal amount, Long accountId) {
        Account account = this.getAccount(accountId);

        if (account.getBalance().compareTo(amount) < 0) {
            throw new InvalidAccountOperationException(
                    String.format("Insufficient funds in account with ID: %s%n" +
                                    "Account has: %s balance, but wants to withdraw: %s",
                            accountId, account.getBalance(), amount));
        }

        account.setBalance(account.getBalance().subtract(amount));
    } //commits the transaction in the end of the method if no error, else rollbacks

    @Override
    public void depositMoney(BigDecimal amount, Long accountId) {
        Account account = this.getAccount(accountId);

        account.setBalance(account.getBalance().add(amount));
    }

    @Override
    public void transferMoney(BigDecimal amount, Long fromAccountId, Long toAccountId) {
        this.withdrawMoney(amount,fromAccountId);
        this.depositMoney(amount,toAccountId);
    }

    @Override
    public List<Account> getAllAccounts() {
        return this.accountRepo.findAll();
    }

    private Account getAccount(Long accountId) {
        Account account = accountRepo.findById(accountId).orElseThrow(() ->
                new NonExistingEntityException(
                        String.format("Account with ID: %s does not exist in the database",
                                accountId)
                ));
        return account;
    }
}
