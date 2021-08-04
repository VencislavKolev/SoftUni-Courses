package timeServer;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.time.DateTimeException;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.logging.*;

public class TimeServer {
    static final int PORT = 8080;
    private static final Logger logger = Logger.getLogger(TimeServer.class.getName());

    public static void main(String[] args) throws IOException {

        System.out.println(logger.getParent());
        logger.setUseParentHandlers(false);
        Handler consoleHandler = new ConsoleHandler();
        Handler fileHandler = new FileHandler("timeservice-log.%u.%g.txt", 1024 * 1024, 3);
        consoleHandler.setLevel(Level.FINE);
        fileHandler.setLevel(Level.INFO);
        fileHandler.setFormatter(new SimpleFormatter());
        logger.addHandler(consoleHandler);
        logger.addHandler(fileHandler);
        logger.setLevel(Level.ALL);
        logger.getParent().setLevel(Level.ALL);
        System.out.println(logger.getUseParentHandlers());

        try (ServerSocket serverSocket = new ServerSocket(PORT)) {
            logger.log(Level.INFO, "TimeServer started on port: " + serverSocket.getLocalPort());

            while (true) {
                try (Socket socket = serverSocket.accept()) {
                    logger.log(Level.INFO, "TimeServer connection accepted: " + socket);
                    BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                    PrintWriter out = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())), true);

                    String zone = in.readLine();
                    logger.log(Level.FINE, "Client time request for zone: " + zone);
                    ZoneId zoneId;
                    try {
                        zoneId = ZoneId.of(zone);
                    } catch (DateTimeException dte) {
                        logger.log(Level.SEVERE, "Invalid zone id: " + zone + ". Showing Greenwich zone instead", dte);
                        zoneId = ZoneId.of("Europe/London");
                    }
                    LocalDateTime now = LocalDateTime.now(zoneId);
                    out.println(now);
                } catch (IOException ioe) {
                    ioe.printStackTrace();
                }
            }
        }
    }
}
