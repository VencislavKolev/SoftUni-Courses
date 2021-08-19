package core;

import model.File;
import model.SampleFile;
import shared.FileManager;

import java.util.*;

public class FileExplorer implements FileManager {
    private File root;
    private final Deque<File> bufferStack;

    public FileExplorer() {
        this.root = new SampleFile(1, "Root");
        this.bufferStack = new ArrayDeque<>();
    }

    @Override
    public void addInDirectory(int directorNumber, File file) {
        File parent = this.get(directorNumber);

        if (file == null) {
            throw new IllegalStateException();
        }

        parent.getChildren().add(file);
    }

    @Override
    public File getRoot() {
        return this.root;
    }

    @Override
    public File get(int number) {
        File file = this.getFileByNumber(number);
        if (file == null) {
            throw new IllegalStateException();
        }
        return file;
    }

    @Override
    public Boolean deleteFile(File file) {
        if (file.getNumber() == this.root.getNumber()) {
            this.root = null;
            return true;
        }
        File parentFile = this.findParentFile(file);

        if (parentFile == null) {
            return false;
        }
        parentFile.getChildren()
                .removeIf(child -> child.getNumber() == file.getNumber());
        return true;
    }

    @Override
    public List<File> getFilesInPath(File path) {
        File file = this.get(path.getNumber());
        if (file == null) {
            throw new IllegalStateException();
        }
        return file.getChildren();
    }

    @Override
    public void move(File file, File destination) {
        if (file.getNumber() == this.root.getNumber()) {
            throw new IllegalStateException("Root cannot be moved!");
        }

        this.deleteFile(file);

        File destFile = this.get(destination.getNumber());
        destFile.getChildren().add(file);
    }

    @Override
    public Boolean contains(File file) {
        return this.getFileByNumber(file.getNumber()) != null;
    }

    @Override
    public List<File> getInDepth() {
        List<File> dfsList = new ArrayList<>();

        this.dfs(this.root, dfsList);

        return dfsList;
    }

    @Override
    public List<File> getInLevel() {
        List<File> bfsFiles = new ArrayList<>();
        Queue<File> queue = new ArrayDeque<>();

        queue.offer(this.root);

        while (!queue.isEmpty()) {
            File current = queue.poll();
            bfsFiles.add(current);
            current.getChildren().forEach(queue::offer);
        }
        return bfsFiles;
    }

    @Override
    public void cut(int number) {
        File file = this.get(number);

        if (file == null) {
            throw new IllegalStateException();
        }
        this.deleteFile(file);

        this.bufferStack.push(file);
    }

    @Override
    public void paste(File destination) {
        if (this.bufferStack.isEmpty()) {
            return;
        }
        File destFile = this.get(destination.getNumber());
        if (destFile == null) {
            throw new IllegalStateException();
        }

        File toPaste = this.bufferStack.pop();
        destFile.getChildren().add(toPaste);
    }

    @Override
    public Boolean isEmpty() {
        return this.root.getChildren().isEmpty();
    }

    @Override
    public String getAsString() {
        if (this.root == null) {
            return "";
        }
        StringBuilder buffer = new StringBuilder();
        print(this.root, buffer, "", "");
        return buffer.toString().trim();
    }

    private void print(File file, StringBuilder buffer, String prefix, String childrenPrefix) {
        buffer.append(prefix);
        buffer.append(file.getNumber());
        buffer.append(System.lineSeparator());
        List<File> children = file.getChildren();
        for (int i = 0; i < children.size(); i++) {
            File next = children.get(i);
            if (i < children.size() - 1) {
                print(next, buffer, childrenPrefix + "├── ", childrenPrefix + "│   ");
            } else {
                print(next, buffer, childrenPrefix + "└── ", childrenPrefix + "    ");
            }
        }
    }

    private void dfs(File root, List<File> dfsFiles) {
        if (root == null) {
            return;
        }
        dfsFiles.add(root);

        root.getChildren()
                .forEach(child -> this.dfs(child, dfsFiles));
    }

    private File getFileByNumber(int number) {
        Queue<File> queue = new ArrayDeque<>();
        queue.offer(this.root);

        while (!queue.isEmpty()) {
            File curr = queue.poll();

            if (curr.getNumber() == number) {
                return curr;
            }
            curr.getChildren().forEach(queue::offer);
        }
        return null;
    }

    private File findParentFile(File file) {
        Queue<File> queue = new ArrayDeque<>();
        queue.offer(this.root);

        while (!queue.isEmpty()) {
            File current = queue.poll();

            for (File child : current.getChildren()) {
                if (child.getNumber() == file.getNumber()) {
                    return current;
                }
                queue.offer(child);
            }
        }
        return null;
    }
}
