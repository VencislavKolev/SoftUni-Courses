package Olympics;

import java.util.*;
import java.util.stream.Collectors;

public class OlympicsImpl implements Olympics {

    private Map<Integer, Competition> competitionSet;
    private Map<Integer, Competitor> competitorSet;
    private Map<String, Set<Competitor>> competitorNames;
    //private Map<String, List<Competitor>> competitorNames;

    public OlympicsImpl() {
        this.competitionSet = new HashMap<>();
        this.competitorSet = new HashMap<>();
        this.competitorNames = new TreeMap<>();
    }


    @Override
    public void addCompetitor(int id, String name) {
        if (this.competitorSet.containsKey(id)) {
            throw new IllegalArgumentException("User with this ID already exists.");
        }

        Competitor competitor = new Competitor(id, name);
        this.competitorSet.put(id, competitor);

        if (!this.competitorNames.containsKey(name)) {
            this.competitorNames.put(name, new TreeSet<>(Comparator.comparing(Competitor::getId)));
            //this.competitorNames.put(name, new ArrayList<>());
        }
        this.competitorNames.get(name).add(competitor);
    }

    @Override
    public void addCompetition(int id, String name, int score) {
        if (this.competitionSet.containsKey(id)) {
            throw new IllegalArgumentException("Competition with this ID already exists.");
        }
        this.competitionSet.put(id, new Competition(name, id, score));
    }

    @Override
    public void compete(int competitorId, int competitionId) {
        var competitor = this.competitorSet.get(competitorId);
        var competition = this.competitionSet.get(competitionId);
        if (competitor == null || competition == null) {
            throw new IllegalArgumentException();
        }

        //competitor
        competitor.setTotalScore(competitor.getTotalScore() + competition.getScore());
        competition.getCompetitors().add(competitor);
//        competition.setScore((int) (competition.getScore() + competitor.getTotalScore()));

    }

    @Override
    public void disqualify(int competitionId, int competitorId) {
        var competitor = this.competitorSet.get(competitorId);
        var competition = this.getCompetition(competitionId);

        if (competitor == null || competition == null || !competition.getCompetitors().contains(competitor)) {
            throw new IllegalArgumentException();
        }
        competition.getCompetitors().remove(competitor);
        competitor.setTotalScore(competitor.getTotalScore() - competition.getScore());

    }

    @Override
    public Iterable<Competitor> findCompetitorsInRange(long min, long max) {
        return this.competitorSet.values()
                .stream()
                .filter(x -> x.getTotalScore() > min && x.getTotalScore() <= max)
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Competitor> getByName(String name) {
        if (!this.competitorNames.containsKey(name)) {
            throw new IllegalArgumentException("No such competitor name");
        }

        return this.competitorNames.get(name);
//        return this.competitorNames.get(name)
//                .stream()
//                .sorted(Comparator.comparingInt(Competitor::getId))
//                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Competitor> searchWithNameLength(int minLength, int maxLength) {
        var validNames = this.competitorNames
                .keySet()
                .stream()
                .filter(x -> x.length() >= minLength && x.length() <= maxLength)
                .collect(Collectors.toList());

        if (validNames.isEmpty()) {
            return new ArrayList<>();
        }

        TreeSet<Competitor> competitors = new TreeSet<>(Comparator.comparing(Competitor::getId));
        for (String validName : validNames) {
            competitors.addAll(this.competitorNames.get(validName));
        }
        return competitors;
    }

    @Override
    public Boolean contains(int competitionId, Competitor comp) {
        Competition competition = this.getCompetition(competitionId);
        return competition.getCompetitors().contains(comp);
    }

    @Override
    public int competitionsCount() {
        return this.competitionSet.size();
    }

    @Override
    public int competitorsCount() {
        return this.competitorSet.size();
    }

    @Override
    public Competition getCompetition(int id) {
        if (!this.competitionSet.containsKey(id)) {
            throw new IllegalArgumentException("No such competition");
        }
        return this.competitionSet.get(id);
    }
}
