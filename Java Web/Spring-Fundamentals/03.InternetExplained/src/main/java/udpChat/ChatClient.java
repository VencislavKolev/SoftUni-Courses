package udpChat;

import java.net.DatagramSocket;
import java.net.SocketException;

public class ChatClient {
    public static void main(String[] args) throws SocketException {
        String host = null;
        if (args.length < 1) {
            System.out.println("Usage: java ChatClient <server_hostname>");
            System.exit(0);
        } else {
            host = args[0];
        }

        DatagramSocket socket = new DatagramSocket();
        MessageReceiver receiver = new MessageReceiver(socket);
        MessageSender sender = new MessageSender(socket, host);

        Thread receiverThread = new Thread(receiver);
        Thread senderThread = new Thread(sender);
        receiverThread.start();
        senderThread.start();
    }
}

//class MessageReceiver implements Runnable {
//    DatagramSocket socket;
//    byte[] buffer;
//
//    public MessageReceiver(DatagramSocket socket) {
//        this.socket = socket;
//        this.buffer = new byte[1024];
//    }
//
//    @Override
//    public void run() {
//        while (true) {
//            try {
//                DatagramPacket packet = new DatagramPacket(this.buffer, this.buffer.length);
//                this.socket.receive(packet);
//                String received = new String(packet.getData());
//                System.out.println(received.trim());
//            } catch (IOException e) {
//                System.err.println(e.getMessage());
//            }
//        }
//    }
//}
//
//class MessageSender implements Runnable {
//
//    public static final int PORT = 7331;
//    private final DatagramSocket socket;
//    private final String hostname;
//
//    public MessageSender(DatagramSocket socket, String hostname) {
//        this.socket = socket;
//        this.hostname = hostname;
//    }
//
//    private void sendMessage(String message) throws IOException {
//        byte[] buffer = message.getBytes();
//        InetAddress address = InetAddress.getByName(hostname);
//        DatagramPacket packet = new DatagramPacket(buffer, buffer.length, address, PORT);
//        socket.send(packet);
//    }
//
//    @Override
//    public void run() {
//        boolean connected = false;
//        do {
//            try {
//                this.sendMessage("Hello");
//                connected = true;
//            } catch (IOException e) {
//                e.printStackTrace();
//            }
//        } while (!connected);
//
//        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
//        while (true) {
//            try {
//                while (!in.ready()) {
//                    Thread.sleep(100);
//                    this.sendMessage(in.readLine());
//                }
//            } catch (IOException | InterruptedException e) {
//                System.err.println(e.getMessage());
//            }
//        }
//    }
//}
//
