// Write your Checker class here

class Checker implements Comparator<Player> {

    private String removeFirst(String value) {
        if (value.length() <= 1)
            return "";
        else
            return value.substring(1);
    }
    
    public int compare(Player o1, Player o2) {
        if (o1.score > o2.score)
            return -1;
        else if (o1.score < o2.score)
            return 1;
        else {
            int c1 = 0, c2 = 0;
            String n1 = o1.name, n2 = o2.name;
            if ( n1 != n2) {
                while (true) {
                    c1 = java.lang.Character.getNumericValue(n1.charAt(0));
                    c2 = java.lang.Character.getNumericValue(n2.charAt(0));
                    if (c1 != c2)
                        break;
                    n1 = removeFirst(n1);
                    n2 = removeFirst(n2);
                    if (n1 == "") {
                        c1 = 0;
                        break;
                    }
                    else if (n2 == "") {
                        c2 = 0;
                        break;
                    }
                }
            }
            
            if (c1 > c2)
                return 1;
            else if (c1 < c2)
                return -1;
            else
                return 0;
        }
    }
}