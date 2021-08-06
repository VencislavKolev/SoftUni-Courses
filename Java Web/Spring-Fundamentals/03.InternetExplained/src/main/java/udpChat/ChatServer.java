package udpChat;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.util.*;

public class ChatServer implements Runnable {

    public static final int PORT = 7331;
    private static final int BUFFER = 1024;

    private final DatagramSocket socket;
    private final List<Integer> clientPorts;
    private final List<InetAddress> clientAddresses;
    private final Set<String> existingClients;

    public ChatServer() throws SocketException {
        this.socket = new DatagramSocket(PORT);
        this.clientPorts = new ArrayList<>();
        this.clientAddresses = new ArrayList<>();
        this.existingClients = new HashSet<>();
    }

    public static void main(String[] args) throws SocketException {
        ChatServer chatServer = new ChatServer();
        chatServer.run();
    }

    @Override
    public void run() {
        byte[] buffer = new byte[BUFFER];
        while (true) {
            Arrays.fill(buffer, (byte) 0);
            DatagramPacket packet = new DatagramPacket(buffer, buffer.length);
            try {
                socket.receive(packet);
                String content = new String(buffer, 0, buffer.length);

                InetAddress clientAddress = packet.getAddress();
                int clientPort = packet.getPort();
                String clientId = clientAddress.toString() + "," + clientPort;

                if (!this.existingClients.contains(clientId)) {
                    this.existingClients.add(clientId);
                    this.clientAddresses.add(clientAddress);
                    this.clientPorts.add(clientPort);
                }

                System.out.println(clientId + " : " + content.trim());
                byte[] data = (clientId + " : " + content).getBytes();

                for (int i = 0; i < clientAddresses.size(); i++) {
                    InetAddress currAddress = this.clientAddresses.get(i);
                    int currPort = this.clientPorts.get(i);
                    packet = new DatagramPacket(data, data.length, currAddress, currPort);
                    socket.send(packet);
                }
            } catch (IOException e) {
                System.err.println(e.getMessage());
            }
        }
    }
}
