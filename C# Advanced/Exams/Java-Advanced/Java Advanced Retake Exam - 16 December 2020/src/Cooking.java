import java.util.*;
import java.util.stream.Collectors;

public class Cooking {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayDeque<Integer> liquids = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .boxed()
                .collect(Collectors.toCollection(ArrayDeque::new));

        ArrayDeque<Integer> ingredients = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .boxed()
                .collect(Collectors.toCollection(ArrayDeque::new));

        HashMap<String, Integer> foodMap = new HashMap<>();
        foodMap.put("Bread", 0);
        foodMap.put("Cake", 0);
        foodMap.put("Fruit Pie", 0);
        foodMap.put("Pastry", 0);

        while (!liquids.isEmpty() && !ingredients.isEmpty()) {
            int liquid = liquids.poll();
            int ingredient = ingredients.pollLast();

            int sum = liquid + ingredient;
            int currQty;
            boolean isCooked = true;
            switch (sum) {
                case 25:
                    currQty = foodMap.get("Bread");
                    foodMap.replace("Bread", currQty + 1);
                    break;
                case 50:
                    currQty = foodMap.get("Cake");
                    foodMap.replace("Cake", currQty + 1);
                    break;
                case 75:
                    currQty = foodMap.get("Pastry");
                    foodMap.replace("Pastry", currQty + 1);
                    break;
                case 100:
                    currQty = foodMap.get("Fruit Pie");
                    foodMap.replace("Fruit Pie", currQty + 1);
                    break;
                default:
                    isCooked = false;
                    break;
            }
            if (!isCooked) {
                ingredients.offer(ingredient + 3);
            }
        }

        boolean haveCookedAll = foodMap.entrySet().stream()
                .allMatch(x -> x.getValue() != 0);

        if (haveCookedAll) {
            System.out.println("Wohoo! You succeeded in cooking all the food!");
        } else {
            System.out.println("Ugh, what a pity! You didn't have enough materials to to cook everything.");
        }
        if (liquids.isEmpty()) {
            System.out.println("Liquids left: none");
        } else {
            String liquidValues = liquids.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", "));

            System.out.println("Liquids left: " + liquidValues);
        }
        if (ingredients.isEmpty()) {
            System.out.println("Ingredients left: none");
        } else {
            List<Integer> reversed = new ArrayList<>(ingredients);
            Collections.reverse(reversed);

            String ingredientValues = reversed
                    .stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", "));
            System.out.println("Ingredients left: " + ingredientValues);
        }

        foodMap = foodMap.entrySet().stream()
                .sorted(Map.Entry.comparingByKey())
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue,
                        (e1, e2) -> e1, LinkedHashMap::new));

        foodMap.forEach((key, value) -> System.out.println(key + ": " + value));
    }
}
