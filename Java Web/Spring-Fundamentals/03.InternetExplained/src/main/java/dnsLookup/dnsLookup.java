package dnsLookup;

import java.io.IOException;
import java.net.InetAddress;
import java.util.Scanner;

public class dnsLookup {
    public static void main(String[] args) throws IOException {
        Scanner scanner = new Scanner(System.in);
        String dns = scanner.nextLine();
        InetAddress[] addresses = InetAddress.getAllByName(dns);
        for (InetAddress a : addresses) {
            String domain = a.getCanonicalHostName();
            System.out.printf("%s --> %s [Accessible: %s]\n", a, domain, a.isReachable(2000));
        }
    }
}
