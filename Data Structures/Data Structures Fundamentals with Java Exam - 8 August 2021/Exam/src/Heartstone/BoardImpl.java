package Heartstone;

import java.util.*;
import java.util.stream.Collectors;

public class BoardImpl implements Board {

    private final Map<String, Card> cardMap;

    public BoardImpl() {
        this.cardMap = new HashMap<>();
    }

    @Override
    public void draw(Card card) {
        if (this.contains(card.getName())) {
            throw new IllegalArgumentException("Card already exists.");
        }

        this.cardMap.put(card.getName(), card);
    }

    @Override
    public Boolean contains(String name) {
        return this.cardMap.containsKey(name);
    }

    @Override
    public int count() {
        return this.cardMap.size();
    }

    @Override
    public void play(String attackerCardName, String attackedCardName) {
        Card attacker = this.cardMap.get(attackerCardName);
        Card defender = this.cardMap.get(attackedCardName);

        if (attacker == null || defender == null || attacker.getLevel() != defender.getLevel()) {
            throw new IllegalArgumentException();
        }

        if (defender.getHealth() <= 0 || attacker.getHealth() <= 0) {
            return;
        }

        defender.setHealth(defender.getHealth() - attacker.getDamage());
        if (defender.getHealth() <= 0) {
            attacker.setScore(attacker.getScore() + defender.getLevel());
        }
    }

    @Override
    public void remove(String name) {
        if (!this.contains(name)) {
            throw new IllegalArgumentException();
        }
        this.cardMap.remove(name);
    }

    @Override
    public void removeDeath() {
        this.cardMap.entrySet().removeIf(x -> x.getValue().getHealth() <= 0);
    }

    @Override
    public Iterable<Card> getBestInRange(int start, int end) {
        return this.cardMap.values()
                .stream()
                .filter(x -> x.getScore() >= start && x.getScore() <= end)
                .sorted(Comparator.comparing(Card::getLevel).reversed())
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Card> listCardsByPrefix(String prefix) {
        return this.cardMap.values()
                .stream()
                .filter(card -> card.getName().startsWith(prefix))
                .sorted(BoardImpl::compare)
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Card> searchByLevel(int level) {
        return this.cardMap.values()
                .stream()
                .filter(x -> x.getLevel() == level)
                .sorted(Comparator.comparing(Card::getScore).reversed())
                .collect(Collectors.toList());
    }

    @Override
    public void heal(int health) {
        this.cardMap.values()
                .stream()
                .min(Comparator.comparing(Card::getHealth))
                .ifPresent(card -> card.increaseHealth(health));
    }

    private static int compare(Card card1, Card card2) {
        String reverseName1 = new StringBuilder(card1.getName()).reverse().toString();
        String reverseName2 = new StringBuilder(card2.getName()).reverse().toString();

        if (reverseName1.compareTo(reverseName2) == 0)
            return card1.getLevel() - card2.getLevel();

        return reverseName1.compareTo(reverseName2);
    }
}
