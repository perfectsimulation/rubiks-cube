import java.util.Arrays;
import java.util.concurrent.ThreadLocalRandom;

/**
 *  The Cube class contains all methods relating to the manipulation of a
 *  Rubik's Cube (RC), as well as a Cube constructor. All algorithms for
 *  RC solutions are also contained within this class. An algorithm in this
 *  context is simply a series of rotations. There are 12 possible rotations,
 *  each defined as a method.
 */

public class Cube {

    private int white  = 0;
    private int red    = 1;
    private int blue   = 2;
    private int orange = 3;
    private int green  = 4;
    private int yellow = 5;
    private int[][][] cube = new int[6][3][3];

    /**
     *  The Cube constructor instantiates a Cube that is unsolved.
     *  The Cube is represented as a 3D array of integers.
     *  AN IMPORTANT NOTE on indices: Please refer to the image file for a
     *  diagram of the indexing conventions.
     */
    public Cube() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                cube[0][i][j] = white;
                cube[1][i][j] = red;
                cube[2][i][j] = blue;
                cube[3][i][j] = orange;
                cube[4][i][j] = green;
                cube[5][i][j] = yellow;
            }
        }
        this.scramble();
    }

    /**
     *  The scramble method applies 40-80 random rotations on a Cube object.
     *
     *  @return     the scrambled Cube
     */
    public Cube scramble() {
        int turns;
        turns = ThreadLocalRandom.current().nextInt(40, 80);
        for (int i = 0; i < turns; i++) {
            int method;
            method = ThreadLocalRandom.current().nextInt(0, 12);
            switch (method) {
                case 0:  this.cw__F();
                //System.out.println("F");
                         break;
                case 1:  this.ccw_F();
                //System.out.println("F'");
                         break;
                case 2:  this.cw__B();
                //System.out.println("B");
                         break;
                case 3:  this.ccw_B();
                //System.out.println("B'");
                         break;
                case 4:  this.cw__R();
                //System.out.println("R");
                         break;
                case 5:  this.ccw_R();
                //System.out.println("R'");
                         break;
                case 6:  this.cw__L();
                //System.out.println("L");
                         break;
                case 7:  this.ccw_L();
                //System.out.println("L'");
                         break;
                case 8:  this.cw__U();
                //System.out.println("U");
                         break;
                case 9:  this.ccw_U();
                //System.out.println("U'");
                         break;
                case 10: this.cw__D();
                //System.out.println("D");
                         break;
                case 11: this.ccw_D();
                //System.out.println("D'");
                         break;
            }
        }
        return this;
    }

    /**
     *  The getColor method returns the color of a "cubic."
     *  A cubic will refer to a particular spot on the Cube, defined by
     *  the face, row, and column of that Cube. Each Cube face has nine cubics,
     *  for a total of 54 cubics per Cube. Each color is defined by an integer
     *  value set as a global variable.
     *
     *  @param  i  the index associated with the face of the Cube
     *  @param  j  the index associated with the row of the Cube face
     *  @param  k  the index associated with the column of the Cube face
     *  @return    the integer value associated with the color of the cubic
     */
    public int getColor(int i, int j, int k) {
        return cube[i][j][k];
    }

    /**
     *  The equals method tests if one Cube has the same state as another,
     *  cubic by cubic.
     *  THIS METHOD IS INCOMPLETE. It currently does not work as intended.
     *
     *  @param  obj  the Cube to compare this Cube with
     *  @return      true if both Cubes have the same state, otherwise false
     */
    // @Override
    // public boolean equals(Object obj) {
    //     Cube that = (Cube) obj;
    //     for (int i = 0; i < 6; i++) {
    //         for (int j = 0; j < 3; j++) {
    //             for (int k = 0; k < 3; k++) {
    //                 if (this.getColor(i, j, k) != that.getColor(i, j, k)) {
    //                     System.out.println(i + j + k);
    //                     return false;
    //                 }
    //             }
    //         }
    //     }
    //     return true;
    // }

    /**
     *  The printCube method prints to the console a representation of the Cube
     *  using integer values for each color.
     */
    public void printCube() {
        System.out.println();
        for (int a = 0; a < 6; a++) {
            for (int b = 0; b < 3; b++) {
                for (int c = 0; c < 3; c++) {
                    System.out.print(this.getColor(a, b, c));
                }
                System.out.println();
            }
            System.out.println();
        }
    }

    /**
     *  The cw__F method applies a clockwise rotation to Cube face 0.
     *  Please see the image file for an illustration of this rotation.
     */
    public void cw__F() {
        int[] oldRow = new int[3];
        int[][] oldWhiteFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow[i] = cube[1][0][i];
        }
        for (int j = 0; j < 3; j++) {
            cube[1][0][j] = cube[2][0][j];
            cube[2][0][j] = cube[3][0][j];
            cube[3][0][j] = cube[4][0][j];
            cube[4][0][j] = oldRow[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldWhiteFace[x][y] = cube[0][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[0][q][p] = oldWhiteFace[2 - p][q];
            }
        }
    }

    /**
     *  The ccw_F method applies a counterclockwise rotation to Cube face 0.
     *  Please see the image file for an illustration of this rotation.
     */
    public void ccw_F() {
        int[] oldRow = new int[3];
        int[][] oldWhiteFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow[i] = cube[3][0][i];
        }
        for (int j = 0; j < 3; j++) {
            cube[3][0][j] = cube[2][0][j];
            cube[2][0][j] = cube[1][0][j];
            cube[1][0][j] = cube[4][0][j];
            cube[4][0][j] = oldRow[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldWhiteFace[x][y] = cube[0][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[0][q][p] = oldWhiteFace[p][2 - q];
            }
        }
    }

    /**
     *  The cw__B method applies a clockwise rotation to Cube face 5.
     *  Please see the image file for an illustration of this rotation.
     */
    public void cw__B() {
        int[] oldRow = new int[3];
        int[][] oldYellowFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow[i] = cube[1][2][i];
        }
        for (int j = 0; j < 3; j++) {
            cube[1][2][j] = cube[2][2][j];
            cube[2][2][j] = cube[3][2][j];
            cube[3][2][j] = cube[4][2][j];
            cube[4][2][j] = oldRow[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldYellowFace[x][y] = cube[5][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[5][q][p] = oldYellowFace[p][2 - q];
            }
        }
    }

    /**
     *  The ccw_B method applies a counterclockwise rotation to Cube face 5.
     *  Please see the image file for an illustration of this rotation.
     */
    public void ccw_B() {
        int[] oldRow = new int[3];
        int[][] oldYellowFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow[i] = cube[3][2][i];
        }
        for (int j = 0; j < 3; j++) {
            cube[3][2][j] = cube[2][2][j];
            cube[2][2][j] = cube[1][2][j];
            cube[1][2][j] = cube[4][2][j];
            cube[4][2][j] = oldRow[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldYellowFace[x][y] = cube[5][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[5][q][p] = oldYellowFace[2 - p][q];
            }
        }
    }

    /**
     *  The cw__R method applies a clockwise rotation to Cube face 4.
     *  Please see the image file for an illustration of this rotation.
     */
    public void cw__R() {
        int[] oldRow0 = new int[3];
        int[] oldRow2 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow4 = new int[3];
        int[][] oldRedFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][i][2];
            oldRow2[i] = cube[2][i][0];
            oldRow5[i] = cube[5][i][2];
            oldRow4[i] = cube[4][i][2];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][j][2] = oldRow4[j];
            cube[2][j][0] = oldRow0[2 - j];
            cube[5][j][2] = oldRow2[2 - j];
            cube[4][j][2] = oldRow5[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldRedFace[x][y] = cube[1][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[1][q][p] = oldRedFace[2 - p][q];
            }
        }
    }

    /**
     *  The ccw_R method applies a counterclockwise rotation to Cube face 4.
     *  Please see the image file for an illustration of this rotation.
     */
    public void ccw_R() {
        int[] oldRow0 = new int[3];
        int[] oldRow2 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow4 = new int[3];
        int[][] oldRedFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][i][2];
            oldRow2[i] = cube[2][i][0];
            oldRow5[i] = cube[5][i][2];
            oldRow4[i] = cube[4][i][2];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][j][2] = oldRow2[2 - j];
            cube[2][j][0] = oldRow5[2 - j];
            cube[5][j][2] = oldRow4[j];
            cube[4][j][2] = oldRow0[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldRedFace[x][y] = cube[1][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[1][q][p] = oldRedFace[p][2 - q];
            }
        }
    }

    /**
     *  The cw__L method applies a clockwise rotation to Cube face 2.
     *  Please see the image file for an illustration of this rotation.
     */
    public void cw__L() {
        int[] oldRow0 = new int[3];
        int[] oldRow2 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow4 = new int[3];
        int[][] oldOrangeFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][i][0];
            oldRow2[i] = cube[2][i][2];
            oldRow5[i] = cube[5][i][0];
            oldRow4[i] = cube[4][i][0];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][j][0] = oldRow4[j];
            cube[2][j][2] = oldRow0[2 - j];
            cube[5][j][0] = oldRow2[2 - j];
            cube[4][j][0] = oldRow5[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldOrangeFace[x][y] = cube[3][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[3][q][p] = oldOrangeFace[p][2 - q];
            }
        }
    }

    /**
     *  The ccw_L method applies a counterclockwise rotation to Cube face 2.
     *  Please see the image file for an illustration of this rotation.
     */
    public void ccw_L() {
        int[] oldRow0 = new int[3];
        int[] oldRow2 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow4 = new int[3];
        int[][] oldOrangeFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][i][0];
            oldRow2[i] = cube[2][i][2];
            oldRow5[i] = cube[5][i][0];
            oldRow4[i] = cube[4][i][0];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][j][0] = oldRow2[2 - j];
            cube[2][j][2] = oldRow5[2 - j];
            cube[5][j][0] = oldRow4[j];
            cube[4][j][0] = oldRow0[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldOrangeFace[x][y] = cube[3][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[3][q][p] = oldOrangeFace[2 - p][q];
            }
        }
    }

    /**
     *  The cw__U method applies a clockwise rotation to Cube face 3.
     *  Please see the image file for an illustration of this rotation.
     */
    public void cw__U() {
        int[] oldRow0 = new int[3];
        int[] oldRow1 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow3 = new int[3];
        int[][] oldBlueFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][0][i];
            oldRow1[i] = cube[1][i][2];
            oldRow5[i] = cube[5][2][i];
            oldRow3[i] = cube[3][i][0];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][0][j] = oldRow1[j];
            cube[1][j][2] = oldRow5[2 - j];
            cube[5][2][j] = oldRow3[j];
            cube[3][j][0] = oldRow0[2 - j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldBlueFace[x][y] = cube[2][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[2][q][p] = oldBlueFace[2 - p][q];
            }
        }
    }

    /**
     *  The ccw_U method applies a counterclockwise rotation to Cube face 3.
     *  Please see the image file for an illustration of this rotation.
     */
    public void ccw_U() {
        int[] oldRow0 = new int[3];
        int[] oldRow1 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow3 = new int[3];
        int[][] oldBlueFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][0][i];
            oldRow1[i] = cube[1][i][2];
            oldRow5[i] = cube[5][2][i];
            oldRow3[i] = cube[3][i][0];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][0][j] = oldRow3[2 - j];
            cube[1][j][2] = oldRow0[j];
            cube[5][2][j] = oldRow1[2 - j];
            cube[3][j][0] = oldRow5[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldBlueFace[x][y] = cube[2][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[2][q][p] = oldBlueFace[p][2 - q];
            }
        }
    }

    /**
     *  The cw__D method applies a clockwise rotation to Cube face 1.
     *  Please see the image file for an illustration of this rotation.
     */
    public void cw__D() {
        int[] oldRow0 = new int[3];
        int[] oldRow1 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow3 = new int[3];
        int[][] oldGreenFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][2][i];
            oldRow1[i] = cube[1][i][0];
            oldRow5[i] = cube[5][0][i];
            oldRow3[i] = cube[3][i][2];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][2][j] = oldRow1[j];
            cube[1][j][0] = oldRow5[2 - j];
            cube[5][0][j] = oldRow3[j];
            cube[3][j][2] = oldRow0[2 - j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldGreenFace[x][y] = cube[4][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[4][q][p] = oldGreenFace[p][2 - q];
            }
        }
    }

    /**
     *  The ccw_D method applies a counterclockwise rotation to Cube face 1.
     *  Please see the image file for an illustration of this rotation.
     */
    public void ccw_D() {
        int[] oldRow0 = new int[3];
        int[] oldRow1 = new int[3];
        int[] oldRow5 = new int[3];
        int[] oldRow3 = new int[3];
        int[][] oldGreenFace = new int[3][3];
        for (int i = 0; i < 3; i++) {
            oldRow0[i] = cube[0][2][i];
            oldRow1[i] = cube[1][i][0];
            oldRow5[i] = cube[5][0][i];
            oldRow3[i] = cube[3][i][2];
        }
        for (int j = 0; j < 3; j++) {
            cube[0][2][j] = oldRow3[2 - j];
            cube[1][j][0] = oldRow0[j];
            cube[5][0][j] = oldRow1[2 - j];
            cube[3][j][2] = oldRow5[j];
        }
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                oldGreenFace[x][y] = cube[4][x][y];
            }
        }
        for (int q = 0; q < 3; q++) {
            for (int p = 0; p < 3; p++) {
                cube[4][q][p] = oldGreenFace[2 - p][q];
            }
        }
    }

    /**
     *  The isRightEdge method checks if the specified cubic has been correctly
     *  identified according to its neighboring cubic. An "edge" piece of the
     *  RC has two colors associated with it, and therefore each edge piece has
     *  two cubics. This method ensures that once a cubic candidate with the
     *  correct color has been found, its corresponding cubic also matches.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     *  @param  color  the color of the correct correponding cubic
     *  @return        true if the corresponding cubic matches the appropriate
     *                 color, otherwise false
     */
    public boolean isRightEdge(int i, int j, int k, int color) {
        boolean answer;
        answer = false;
        switch (i) {
            case 0:
                if (j == 0) {
                    if (this.getColor(2, 0, 1) == color) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2) {
                    if (this.getColor(4, 0, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 0) {
                    if (this.getColor(3, 0, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 2) {
                    if (this.getColor(1, 0, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
            case 1:
                if (j == 0) {
                    if (this.getColor(0, 1, 2) == color) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2) {
                    if (this.getColor(5, 1, 2) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 0) {
                    if (this.getColor(4, 1, 2) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 2) {
                    if (this.getColor(2, 1, 0) == color) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
            case 2:
                if (j == 0) {
                    if (this.getColor(0, 0, 1) == color) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2) {
                    if (this.getColor(5, 2, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 0) {
                    if (this.getColor(1, 1, 2) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 2) {
                    if (this.getColor(3, 1, 0) == color) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
            case 3:
                if (j == 0) {
                    if (this.getColor(0, 1, 0) == color) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2) {
                    if (this.getColor(5, 1, 0) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 0) {
                    if (this.getColor(2, 1, 2) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 2) {
                    if (this.getColor(4, 1, 0) == color) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
            case 4:
                if (j == 0) {
                    if (this.getColor(0, 2, 1) == color) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2) {
                    if (this.getColor(5, 0, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 0) {
                    if (this.getColor(3, 1, 2) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 2) {
                    if (this.getColor(1, 1, 0) == color) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
            case 5:
                if (j == 0) {
                    if (this.getColor(4, 2, 1) == color) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2) {
                    if (this.getColor(2, 2, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 0) {
                    if (this.getColor(3, 2, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else if (j == 1 && k == 2) {
                    if (this.getColor(1, 2, 1) == color) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
        }
        return answer;
    }

    /**
     *  The crossed method checks if the "white cross" has been completed.
     *  Please see the image file for an illustration of the white cross state.
     *  
     *  @return    true if the white cross has been completed, otherwise false
     */
    public boolean crossed() {
        int w1;
        int w2;
        int w3;
        int w4;
        int w5;
        int total;
        boolean rr;
        boolean bb;
        boolean oo;
        boolean gg;
        w1 = this.getColor(0, 0, 1);
        w2 = this.getColor(0, 1, 0);
        w3 = this.getColor(0, 1, 1);
        w4 = this.getColor(0, 1, 2);
        w5 = this.getColor(0, 2, 1);
        total = w1 + w2 + w3 + w4 + w5;
        rr = false;
        bb = false;
        oo = false;
        gg = false;
        if (this.getColor(1, 0, 1) == this.getColor(1, 1, 1)) rr = true;
        if (this.getColor(2, 0, 1) == this.getColor(2, 1, 1)) bb = true;
        if (this.getColor(3, 0, 1) == this.getColor(3, 1, 1)) oo = true;
        if (this.getColor(4, 0, 1) == this.getColor(4, 1, 1)) gg = true;
        if (total == 0 && rr && bb && oo && gg) {
            return true;
        } else {
            return false;
        }
    }

    /**
     *  The crossRed method applies an algorithm to the Cube once the correct
     *  edge piece (white + red) has been located.
     *  
     *  @param  i  the index associated with the face of the Cube
     *  @param  j  the index associated with the row of the Cube face
     *  @param  k  the index associated with the column of the Cube face
     */
    public void crossRed(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j == 0) {
                    this.cw__F();
                } else if (j == 2) {
                    this.ccw_F();
                } else if (k == 0) {
                    this.cw__F();
                    this.cw__F();
                } else {}
                break;
            case 1:
                if (j == 0) {
                    this.cw__R();
                    this.cw__U();
                    this.cw__F();
                } else if (j == 2) {
                    this.ccw_R();
                    this.cw__U();
                    this.cw__F();
                } else if (k == 0) {
                    this.cw__D();
                    this.ccw_F();
                } else if (k == 2) {
                    this.cw__U();
                    this.cw__F();
                } else {}
                break;
            case 2:
                if (j == 0) {
                    this.ccw_U();
                    this.ccw_R();
                } else if (j == 2) {
                    this.cw__U();
                    this.ccw_R();
                } else if (k == 0) {
                    this.ccw_R();
                } else if (k == 2) {
                    this.cw__U();
                    this.cw__U();
                    this.ccw_R();
                } else {}
                break;
            case 3:
                if (j == 0) {
                    this.cw__L();
                    this.ccw_U();
                    this.cw__F();
                } else if (j == 2) {
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__F();
                } else if (k == 0) {
                    this.ccw_U();
                    this.cw__F();
                } else if (k == 2) {
                    this.ccw_D();
                    this.ccw_F();
                } else {}
                break;
            case 4:
                if (j == 0) {
                    this.ccw_D();
                    this.cw__R();
                } else if (j == 2) {
                    this.cw__D();
                    this.cw__R();
                } else if (k == 0) {
                    this.cw__D();
                    this.cw__D();
                    this.cw__R();
                } else if (k == 2) {
                    this.cw__R();
                } else {}
                break;
            case 5:
                if (j == 0) {
                    this.ccw_B();
                    this.cw__R();
                    this.cw__R();
                } else if (j == 2) {
                    this.cw__B();
                    this.cw__R();
                    this.cw__R();
                } else if (k == 0) {
                    this.cw__L();
                    this.cw__L();
                    this.cw__F();
                    this.cw__F();
                } else if (k == 2) {
                    this.cw__R();
                    this.cw__R();
                } else {}
                break;
        }
    }

    /**
     *  The crossBlue method applies an algorithm to the Cube once the correct
     *  edge piece (white + blue) has been located.
     *  
     *  @param  i  the index associated with the face of the Cube
     *  @param  j  the index associated with the row of the Cube face
     *  @param  k  the index associated with the column of the Cube face
     */
    public void crossBlue(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j == 2) {
                    this.cw__D();
                    this.cw__D();
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (j == 1) {
                    this.cw__R();
                    this.cw__R();
                    this.cw__F();
                    this.cw__R();
                    this.cw__R();
                }
                break;
            case 1:
                if (j == 2) {
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                }
                if (k == 0) {
                    this.ccw_D();
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (k == 2) {
                    this.cw__U();
                }
                break;
            case 2:
                if (j == 0) {
                    this.cw__U();
                    this.cw__L();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (j == 2) {
                    this.ccw_U();
                    this.ccw_R();
                    this.ccw_F();
                    this.ccw_L();
                    this.cw__F();
                    this.cw__R();
                }
                if (k == 0) {
                    this.ccw_R();
                    this.ccw_F();
                    this.cw__R();
                }
                if (k == 2) {
                    this.cw__L();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                break;
            case 3:
                if (j == 0) {
                    this.cw__L();
                    this.ccw_U();
                }
                if (j == 2) {
                    this.ccw_L();
                    this.ccw_U();
                }
                if (k == 0) {
                    this.ccw_U();
                }
                if (k == 2) {
                    this.cw__L();
                    this.cw__L();
                    this.ccw_U();
                }
                break;
            case 4:
                if (j == 0) {
                    this.cw__D();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (j == 2) {
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (k == 0) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (k == 2) {
                    this.cw__D();
                    this.cw__D();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                break;
            case 5:
                if (j == 0) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (j == 2) {
                    this.cw__U();
                    this.cw__U();
                }
                if (k == 0) {
                    this.cw__B();
                    this.cw__U();
                    this.cw__U();
                }
                if (k == 2) {
                    this.ccw_B();
                    this.cw__U();
                    this.cw__U();
                }
                break;
        }
    }

    /**
     *  The crossOrange method applies an algorithm to the Cube once the
     *  correct edge piece (white + orange) has been located.
     *  
     *  @param  i  the index associated with the face of the Cube
     *  @param  j  the index associated with the row of the Cube face
     *  @param  k  the index associated with the column of the Cube face
     */
    public void crossOrange(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j == 2) {
                    this.cw__D();
                    this.cw__D();
                    this.cw__B();
                    this.cw__L();
                    this.cw__L();
                }
                break;
            case 1:
                if (j == 2) {
                    this.cw__B();
                    this.ccw_D();
                    this.cw__L();
                }
                if (k == 0) {
                    this.ccw_D();
                    this.cw__B();
                    this.cw__L();
                    this.cw__L();
                }
                if (k == 2) {
                    this.cw__U();
                    this.cw__R();
                    this.cw__R();
                    this.ccw_F();
                    this.ccw_U();
                    this.cw__R();
                    this.cw__R();
                }
                break;
            case 2:
                if (j == 2) {
                    this.ccw_B();
                    this.cw__L();
                    this.ccw_F();
                    this.ccw_D();
                    this.cw__F();
                }
                if (k == 0) {
                    this.cw__R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.cw__L();
                    this.ccw_R();
                }
                if (k == 2) {
                    this.ccw_L();
                }
                break;
            case 3:
                if (j == 0) {
                    this.ccw_L();
                    this.ccw_F();
                    this.ccw_D();
                    this.cw__F();
                }
                if (j == 2) {
                    this.cw__L();
                    this.ccw_F();
                    this.ccw_D();
                    this.cw__F();
                }
                if (k == 0) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                }
                if (k == 2) {
                    this.ccw_F();
                    this.ccw_D();
                    this.cw__F();
                }
                break;
            case 4:
                if (j == 0) {
                    this.cw__D();
                    this.cw__L();
                }
                if (j == 2) {
                    this.ccw_D();
                    this.cw__L();
                }
                if (k == 0) {
                    this.cw__L();
                }
                if (k == 2) {
                    this.cw__D();
                    this.cw__D();
                    this.cw__L();
                }
                break;
            case 5:
                if (j == 0) {
                    this.cw__B();
                    this.cw__L();
                    this.cw__L();
                }
                if (j == 2) {
                    this.ccw_B();
                    this.cw__L();
                    this.cw__L();
                }
                if (k == 0) {
                    this.cw__L();
                    this.cw__L();
                }
                if (k == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.cw__L();
                }
                break;
        }
    }

    /**
     *  The crossGreen method applies an algorithm to the Cube once the
     *  correct edge piece (white + green) has been located.
     *  
     *  @param  i  the index associated with the face of the Cube
     *  @param  j  the index associated with the row of the Cube face
     *  @param  k  the index associated with the column of the Cube face
     */
    public void crossGreen(int i, int j, int k) {
        switch (i) {
            case 0:
                break;
            case 1:
                if (j == 2) {
                    this.cw__R();
                    this.cw__D();
                    this.ccw_R();
                }
                if (k == 0) {
                    this.cw__D();
                }
                if (k == 2) {
                    this.cw__R();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.cw__R();
                }
                break;
            case 2:
                if (j == 2) {
                    this.ccw_B();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                }
                if (k == 0) {
                    this.ccw_U();
                    this.cw__B();
                    this.cw__R();
                    this.cw__D();
                    this.ccw_R();
                    this.cw__U();
                }
                if (k == 2) {
                    this.cw__L();
                    this.ccw_B();
                    this.cw__D();
                    this.cw__D();
                    this.ccw_L();
                }
                break;
            case 3:
                if (j == 2) {
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                }
                if (k == 0) {
                    this.cw__L();
                    this.cw__L();
                    this.ccw_D();
                    this.cw__L();
                    this.cw__L();
                }
                if (k == 2) {
                    this.ccw_D();
                }
                break;
            case 4:
                if (j == 0) {
                    this.ccw_D();
                    this.ccw_F();
                    this.cw__R();
                    this.cw__F();
                }
                if (j == 2) {
                    this.ccw_D();
                    this.cw__F();
                    this.cw__L();
                    this.ccw_F();
                }
                if (k == 0) {
                    this.cw__F();
                    this.cw__L();
                    this.ccw_F();
                }
                if (k == 2) {
                    this.ccw_F();
                    this.cw__R();
                    this.cw__F();
                }
                break;
            case 5:
                if (j == 0) {
                    this.cw__D();
                    this.cw__D();
                }
                if (j == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__D();
                    this.cw__D();
                }
                if (k == 0) {
                    this.ccw_B();
                    this.cw__D();
                    this.cw__D();
                }
                if (k == 2) {
                    this.cw__B();
                    this.cw__D();
                    this.cw__D();
                }
                break;
        }
    }

    /**
     *  The isRightCorner method checks if the specified cubic has been
     *  correctly identified according to its neighboring cubics. A "corner"
     *  piece of the RC has three colors associated with it, and therefore each
     *  corner piece has three cubics. This method ensures that once a cubic
     *  candidate with the correct color has been found, its corresponding
     *  cubics also match.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     *  @param  color  the color of the correct correponding cubic
     *  @return        true if the corresponding cubics match the appropriate
     *                 colors, otherwise false
     */
    public boolean isRightCorner(int i, int j, int k, int color) {
        boolean answer;
        answer = false;
        switch (i) {
            case 0:
                if (j + k == 0) {
                    if (this.getColor(2, 0, 2) == color
                     && this.getColor(3, 0, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 0 && k == 2) {
                    if (this.getColor(1, 0, 2) == color
                     && this.getColor(2, 0, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2 && k == 0) {
                    if (this.getColor(3, 0, 2) == color
                     && this.getColor(4, 0, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j + k == 4) {
                    if (this.getColor(4, 0, 2) == color
                     && this.getColor(1, 0, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else {}
                break;
            case 1:
                if (j + k == 0) {
                    if (this.getColor(0, 2, 2) == color
                     && this.getColor(4, 0, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 0 && k == 2) {
                    if (this.getColor(2, 0, 0) == color
                     && this.getColor(0, 0, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2 && k == 0) {
                    if (this.getColor(4, 2, 2) == color
                     && this.getColor(5, 0, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j + k == 4) {
                    if (this.getColor(5, 2, 2) == color
                     && this.getColor(2, 2, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else {}
                break;
            case 2:
                if (j + k == 0) {
                    if (this.getColor(0, 0, 2) == color
                     && this.getColor(1, 0, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 0 && k == 2) {
                    if (this.getColor(3, 0, 0) == color
                     && this.getColor(0, 0, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2 && k == 0) {
                    if (this.getColor(1, 2, 2) == color
                     && this.getColor(5, 2, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j + k == 4) {
                    if (this.getColor(5, 2, 0) == color
                     && this.getColor(3, 2, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else {}
                break;
            case 3:
                if (j + k == 0) {
                    if (this.getColor(0, 0, 0) == color
                     && this.getColor(2, 0, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 0 && k == 2) {
                    if (this.getColor(4, 0, 0) == color
                     && this.getColor(0, 2, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2 && k == 0) {
                    if (this.getColor(2, 2, 2) == color
                     && this.getColor(5, 2, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j + k == 4) {
                    if (this.getColor(5, 0, 0) == color
                     && this.getColor(4, 2, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else {}
                break;
            case 4:
                if (j + k == 0) {
                    if (this.getColor(0, 2, 0) == color
                     && this.getColor(3, 0, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 0 && k == 2) {
                    if (this.getColor(1, 0, 0) == color
                     && this.getColor(0, 2, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2 && k == 0) {
                    if (this.getColor(3, 2, 2) == color
                     && this.getColor(5, 0, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j + k == 4) {
                    if (this.getColor(5, 0, 2) == color
                     && this.getColor(1, 2, 0) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else {}
                break;
            case 5:
                if (j + k == 0) {
                    if (this.getColor(4, 2, 0) == color
                     && this.getColor(3, 2, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 0 && k == 2) {
                    if (this.getColor(1, 2, 0) == color
                     && this.getColor(4, 2, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j == 2 && k == 0) {
                    if (this.getColor(3, 2, 0) == color
                     && this.getColor(2, 2, 2) == 0) {
                        answer = true;
                        return answer;
                    } 
                } else if (j + k == 4) {
                    if (this.getColor(2, 2, 0) == color
                     && this.getColor(1, 2, 2) == 0) {
                        answer = true;
                        return answer;
                    }
                } else {}
                break;
        }
        return answer;
    }

    /**
     *  The cornered method checks if the first layer of the Cube has been
     *  solved. Please see the image file for a diagram of the layers of a RC.
     *
     *  @return    true if the first layer has been completed, otherwise false
     */
    public boolean cornered() {
        int w1;
        int w2;
        int w3;
        int w4;
        int total;
        boolean rb;
        boolean bo;
        boolean og;
        boolean gr;
        int rb1;
        int rb2;
        int bo1;
        int bo2;
        int og1;
        int og2;
        int gr1;
        int gr2;
        w1 = this.getColor(0, 0, 2);
        w2 = this.getColor(0, 0, 0);
        w3 = this.getColor(0, 2, 0);
        w4 = this.getColor(0, 2, 2);
        total = w1 + w2 + w3 + w4;
        rb = false;
        bo = false;
        og = false;
        gr = false;
        rb1 = this.getColor(1, 0, 2);
        rb2 = this.getColor(2, 0, 0);
        bo1 = this.getColor(2, 0, 2);
        bo2 = this.getColor(3, 0, 0);
        og1 = this.getColor(3, 0, 2);
        og2 = this.getColor(4, 0, 0);
        gr1 = this.getColor(4, 0, 2);
        gr2 = this.getColor(1, 0, 0);
        if (rb1 == 1 && rb2 == 2) rb = true;
        if (bo1 == 2 && bo2 == 3) bo = true;
        if (og1 == 3 && og2 == 4) og = true;
        if (gr1 == 4 && gr2 == 1) gr = true;
        if (total == 0 && rb && bo && og && gr) {
            return true;
        } else {
            return false;
        }
    }

    /**
     *  The cornerRed method applies an algorithm to the cube once the correct
     *  corner piece (white + red + blue) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void cornerRed(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j + k == 0) {
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j == 0 && k == 2) {
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j == 2 && k == 0) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j + k == 4) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else {}
                break;
            case 1:
                if (j + k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j == 2 && k == 0) {
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.ccw_B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j + k == 4) {
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else {}
                break;
            case 2:
                if (j + k == 0) {
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j == 0 && k == 2) {
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                } else if (j == 2 && k == 0) {
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else {}
                break;
            case 3:
                if (j + k == 0) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                } else if (j == 0 && k == 2) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j == 2 && k == 0) {
                    this.cw__L();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else {}
                break;
            case 4:
                if (j + k == 0) {
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j == 0 && k == 2) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j == 2 && k == 0) {
                    this.ccw_B();
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else if (j + k == 4) {
                    this.ccw_B();
                    this.ccw_U();
                    this.cw__B();
                    this.cw__U();
                } else {}
                break;
            case 5:
                if (j + k == 0) {
                    this.ccw_B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j == 0 && k == 2) {
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j == 2 && k == 0) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                } else {}
                break;
        }
    }

    /**
     *  The cornerBlue method applies an algorithm to the cube once the correct
     *  corner piece (white + blue + orange) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void cornerBlue(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j + k == 0) {
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j == 2 && k == 0) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j + k == 4) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else {}
                break;
            case 1:
                if (j + k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j == 2 && k == 0) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j + k == 4) {
                    this.ccw_B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else {}
                break;
            case 2:
                if (j == 2 && k == 0) {
                    this.ccw_B();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j + k == 4) {
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else {}
                break;
            case 3:
                if (j + k == 0) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j == 0 && k == 2) {
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j == 2 && k == 0) {
                    this.cw__L();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else {}
                break;
            case 4:
                if (j + k == 0) {
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j == 0 && k == 2) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else if (j == 2 && k == 0) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                } else {}
                break;
            case 5:
                if (j + k == 0) {
                    this.cw__B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j == 0 && k == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j == 2 && k == 0) {
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else if (j + k == 4) {
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_B();
                    this.ccw_U();
                } else {}
                break;
        }
    }

    /**
     *  The cornerOrange method applies an algorithm to the cube once the
     *  correct corner piece (white + orange + green) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void cornerOrange(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j == 2 && k == 0) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else if (j + k == 4) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else {}
                break;
            case 1:
                if (j + k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j == 2 && k == 0) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else {}
                break;
            case 2:
                if (j == 2 && k == 0) {
                    this.cw__B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else if (j + k == 4) {
                    this.ccw_B();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else {}
                break;
            case 3:
                if (j == 2 && k == 0) {
                    this.ccw_B();
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__B();
                    this.cw__B();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else if (j + k == 4) {
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else {}
                break;
            case 4:
                if (j + k == 0) {
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j == 0 && k == 2) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j == 2 && k == 0) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__D();
                    this.cw__B();
                    this.ccw_D();
                } else {}
                break;
            case 5:
                if (j + k == 0) {
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j == 0 && k == 2) {
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j == 2 && k == 0) {
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_L();
                    this.ccw_B();
                    this.cw__L();
                } else {}
                break;
        }
    }

    /**
     *  The cornerGreen method applies an algorithm to the cube once the
     *  correct corner piece (white + green + red) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void cornerGreen(int i, int j, int k) {
        switch (i) {
            case 0:
                if (j + k == 4) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else {}
                break;
            case 1:
                if (j + k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_B();
                    this.cw__D();
                } else if (j == 2 && k == 0) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else {}
                break;
            case 2:
                if (j == 2 && k == 0) {
                    this.cw__B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else {}
                break;
            case 3:
                if (j == 2 && k == 0) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else if (j + k == 4) {
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else {}
                break;
            case 4:
                if (j == 2 && k == 0) {
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.ccw_B();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else if (j + k == 4) {
                    this.ccw_R();
                    this.cw__B();
                    this.cw__R();
                } else {}
                break;
            case 5:
                if (j + k == 0) {
                    this.ccw_B();
                    this.ccw_D();
                    this.ccw_B();
                    this.cw__D();
                } else if (j == 0 && k == 2) {
                    this.ccw_D();
                    this.ccw_B();
                    this.cw__D();
                } else if (j == 2 && k == 0) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_D();
                    this.ccw_B();
                    this.cw__D();
                } else if (j + k == 4) {
                    this.cw__B();
                    this.ccw_D();
                    this.ccw_B();
                    this.cw__D();
                } else {}
                break;
        }
    }

    /**
     *  The lay2 method checks if the second layer of the Cube has been solved.
     *  Please see the image file for a diagram of the layers of a RC.
     *
     *  @return    true if the second layer has been solved
     */
    public boolean lay2() {
        boolean rb;
        boolean bo;
        boolean og;
        boolean gr;
        int rb1;
        int rb2;
        int bo1;
        int bo2;
        int og1;
        int og2;
        int gr1;
        int gr2;
        rb = false;
        bo = false;
        og = false;
        gr = false;
        rb1 = this.getColor(1, 1, 2);
        bo1 = this.getColor(2, 1, 2);
        og1 = this.getColor(3, 1, 2);
        gr1 = this.getColor(4, 1, 2);
        rb2 = this.getColor(2, 1, 0);
        bo2 = this.getColor(3, 1, 0);
        og2 = this.getColor(4, 1, 0);
        gr2 = this.getColor(1, 1, 0);
        if (rb1 == 1 && rb2 == 2) rb = true;
        if (bo1 == 2 && bo2 == 3) bo = true;
        if (og1 == 3 && og2 == 4) og = true;
        if (gr1 == 4 && gr2 == 1) gr = true;
        if (rb && bo && og && gr) {
            return true;
        } else {
            return false;
        }
    }

    /**
     *  The lay2Red method applies an algorithm to the cube once the correct
     *  edge piece (red + blue) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void lay2Red(int i, int j, int k) {
        switch (i) {
            case 1:
                if (j == 2) {
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else {}
                break;
            case 2:
                if (j == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 0) {
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                    this.ccw_B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 2) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else {}
                break;
            case 3:
                if (j == 2) {
                    this.ccw_B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 0) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 2) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else {}
                break;
            case 4:
                if (j == 2) {
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 0) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D(); 
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_B();
                    this.cw__U();
                    this.ccw_R();
                    this.cw__U();
                    this.cw__R();
                    this.ccw_U();
                } else if (k == 2) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else {}
                break;
            case 5:
                if (j == 0) {
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else if (j == 2) {
                    this.ccw_B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else if (k == 0) {
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else if (k == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__R();
                    this.cw__B();
                    this.ccw_R();
                    this.cw__U();
                    this.ccw_R();
                    this.ccw_U();
                    this.cw__R();
                } else {}
                break;
        }
    }

    /**
     *  The lay2Blue method applies an algorithm to the cube once the correct
     *  edge piece (blue + orange) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void lay2Blue(int i, int j, int k) {
        switch (i) {
            case 1:
                if (j == 2) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else if (k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else {}
                break;
            case 2:
                if (j == 2) {
                    this.cw__B();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else {}
                break;
            case 3:
                if (j == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else if (k == 0) {
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                    this.ccw_B();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else if (k == 2) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                    this.cw__B();
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__L();
                    this.cw__U();
                } else {}
                break;
            case 4:
                if (j == 2) {
                    this.ccw_B();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else if (k == 0) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                    this.cw__L();
                    this.ccw_B();
                    this.ccw_L();
                    this.ccw_U();
                    this.ccw_L();
                    this.cw__U();
                    this.cw__L();
                } else if (k == 2) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__L();
                    this.cw__U();
                } else {}
                break;
            case 5:
                if (j == 0) {
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__L();
                    this.cw__U();
                } else if (j == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__L();
                    this.cw__U();
                } else if (k == 0) {
                    this.ccw_B();
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__L();
                    this.cw__U();
                } else if (k == 2) {
                    this.cw__B();
                    this.cw__U();
                    this.cw__B();
                    this.ccw_U();
                    this.ccw_L();
                    this.ccw_U();
                    this.cw__L();
                    this.cw__U();
                } else {}
                break;
        }
    }

    /**
     *  The lay2Orange method applies an algorithm to the cube once the correct
     *  edge piece (orange + green) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void lay2Orange(int i, int j, int k) {
        switch (i) {
            case 1:
                if (j == 2) {
                    this.ccw_B();
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                } else if (k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                } else {}
                break;
            case 2:
                if (j == 2) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                } else {}
                break;
            case 3:
                if (j == 2) {
                    this.cw__B();
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                } else {}
                break;
            case 4:
                if (j == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                } else if (k == 0) {
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                    this.ccw_B();
                    this.cw__D();
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__L();
                    this.ccw_D();
                    this.ccw_L();
                    this.cw__D();
                } else if (k == 2) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.cw__B();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_D();
                    this.cw__L();
                    this.cw__D();
                    this.ccw_L();
                } else {}
                break;
            case 5:
                if (j == 0) {
                    this.ccw_B();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_D();
                    this.cw__L();
                    this.cw__D();
                    this.ccw_L();
                } else if (j == 2) {
                    this.cw__B();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_D();
                    this.cw__L();
                    this.cw__D();
                    this.ccw_L();
                } else if (k == 0) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_D();
                    this.cw__L();
                    this.cw__D();
                    this.ccw_L();
                } else if (k == 2) {
                    this.ccw_L();
                    this.cw__B();
                    this.cw__L();
                    this.ccw_D();
                    this.cw__L();
                    this.cw__D();
                    this.ccw_L();
                } else {}
                break;
        }
    }

    /**
     *  The lay2Green method applies an algorithm to the cube once the correct
     *  edge piece (green + red) has been located.
     *
     *  @param  i      the index associated with the face of the Cube
     *  @param  j      the index associated with the row of the Cube face
     *  @param  k      the index associated with the column of the Cube face
     */
    public void lay2Green(int i, int j, int k) {
        switch (i) {
            case 1:
                if (j == 2) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                } else if (k == 0) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                    this.ccw_B();
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                } else {}
                break;
            case 2:
                if (j == 2) {
                    this.ccw_B();
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                } else {}
                break;
            case 3:
                if (j == 2) {
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                } else {}
                break;
            case 4:
                if (j == 2) {
                    this.cw__B();
                    this.ccw_R();
                    this.ccw_B();
                    this.cw__R();
                    this.cw__D();
                    this.cw__R();
                    this.ccw_D();
                    this.ccw_R();
                } else {}
                break;
            case 5:
                if (j == 0) {
                    this.cw__B();
                    this.cw__B();
                    this.ccw_D();
                    this.cw__B();
                    this.cw__D();
                    this.cw__R();
                    this.cw__D();
                    this.ccw_R();
                    this.ccw_D();
                } else if (j == 2) {
                    this.ccw_D();
                    this.cw__B();
                    this.cw__D();
                    this.cw__R();
                    this.cw__D();
                    this.ccw_R();
                    this.ccw_D();
                } else if (k == 0) {
                    this.cw__B();
                    this.ccw_D();
                    this.cw__B();
                    this.cw__D();
                    this.cw__R();
                    this.cw__D();
                    this.ccw_R();
                    this.ccw_D();
                } else if (k == 2) {
                    this.ccw_B();
                    this.ccw_D();
                    this.cw__B();
                    this.cw__D();
                    this.cw__R();
                    this.cw__D();
                    this.ccw_R();
                    this.ccw_D();
                } else {}
                break;
        }
    }







    /**
     *  The yellowed method checks if the last layer of the Cube has been
     *  solved. Please see the image file for a diagram of the layers of a RC.
     *
     *  NOTE: This method works as intended, however the last bit of the third
     *  layer solution code is unfinished. Until it is complete, there is no
     *  need to include this method.
     *
     *  @return    true if the last layer has been completed, otherwise false
     */
    // public boolean yellowed() {
    //     int y00;
    //     int y01;
    //     int y02;
    //     int y10;
    //     int y11;
    //     int y12;
    //     int y20;
    //     int y21;
    //     int y22;
    //     int total;
    //     y00 = this.getColor(5, 0, 0);
    //     y01 = this.getColor(5, 0, 1);
    //     y02 = this.getColor(5, 0, 2);
    //     y10 = this.getColor(5, 1, 0);
    //     y11 = this.getColor(5, 1, 1);
    //     y12 = this.getColor(5, 1, 2);
    //     y20 = this.getColor(5, 2, 0);
    //     y21 = this.getColor(5, 2, 1);
    //     y22 = this.getColor(5, 2, 2);
    //     total = y00 + y01 + y02 + y10 + y11 + y12 + y20 + y21 + y22;
    //     if (total == 45) {
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    /**
     *  The vert method applies an algorithm to the Cube once the proper
     *  cube state has been identified.
     *
     *  NOTE: This method works as intended, however the last bit of the third
     *  layer solution code is unfinished. Until it is complete, there is no
     *  need to include this method.
     */
    // public void vert() {
    //     this.cw__B();
    //     this.cw__U();
    //     this.cw__R();
    //     this.ccw_B();
    //     this.ccw_R();
    //     this.cw__B();
    //     this.ccw_U();
    // }

    /**
     *  The horz method applies an algorithm to the Cube once the proper
     *  cube state has been identified.
     *
     *  NOTE: This method works as intended, however the last bit of the third
     *  layer solution code is unfinished. Until it is complete, there is no
     *  need to include this method.
     */
    // public void horz() {
    //     this.cw__U();
    //     this.cw__R();
    //     this.ccw_B();
    //     this.ccw_R();
    //     this.cw__B();
    //     this.ccw_U();
    // }

    /**
     *  The l method applies an algorithm to the Cube once the proper
     *  cube state has been identified.
     *
     *  NOTE: This method works as intended, however the last bit of the third
     *  layer solution code is unfinished. Until it is complete, there is no
     *  need to include this method.
     */
    // public void l(int corner) {
    //     switch (corner) {
    //         case 1:
    //         case 2:
    //         case 3:
    //         case 4:
    //     }
    // }

    /**
     *  The fish method applies an algorithm to the Cube once the proper
     *  cube state has been identified.
     *
     *  NOTE: This method works as intended, however the last bit of the third
     *  layer solution code is unfinished. Until it is complete, there is no
     *  need to include this method.
     */
    // public void fish(int corner) {
    //     switch (corner) {
    //         case 1:
    //             this.cw__R();
    //             this.ccw_B();
    //             this.ccw_R();
    //             this.ccw_B();
    //             this.cw__R();
    //             this.cw__B();
    //             this.cw__B();
    //             this.ccw_R();
    //             break;
    //         case 2:
    //             this.ccw_L();
    //             this.ccw_B();
    //             this.cw__L();
    //             this.ccw_B();
    //             this.ccw_L();
    //             this.cw__B();
    //             this.cw__B();
    //             this.cw__L();
    //             break;
    //         case 3:
    //             this.cw__R();
    //             this.ccw_B();
    //             this.ccw_R();
    //             this.ccw_B();
    //             this.cw__R();
    //             this.cw__B();
    //             this.cw__B();
    //             this.ccw_R();
    //             break;
    //         case 4:
    //             this.ccw_D();
    //             this.ccw_B();
    //             this.cw__D();
    //             this.ccw_B();
    //             this.ccw_D();
    //             this.cw__B();
    //             this.cw__B();
    //             this.cw__D();
    //     }
    // }

    /**
     *  The debugEdge method prints to the console two cubics if they were
     *  found to be identical. This method was used in the early stages of
     *  development to help identify bugs in rotation methods. The bugs have
     *  since been fixed, but the method remains here for future reference.
     */
    public void debugEdge() {
        if (this.getColor(0,0,1) == this.getColor(2,0,1)) {
            System.out.println("001 201");
        }
        if (this.getColor(0,2,1) == this.getColor(4,0,1)) {
            System.out.println("021 401");
        }
        if (this.getColor(0,1,0) == this.getColor(3,0,1)) {
            System.out.println("010 301");
        }
        if (this.getColor(0,1,2) == this.getColor(1,0,1)) {
            System.out.println("012 101");
        }



        if (this.getColor(1,2,1) == this.getColor(5,1,2)) {
            System.out.println("121 512");
        }
        if (this.getColor(1,1,0) == this.getColor(4,1,2)) {
            System.out.println("110 412");
        }
        if (this.getColor(1,1,2) == this.getColor(2,1,0)) {
            System.out.println("112 210");
        }



        if (this.getColor(2,2,1) == this.getColor(5,2,1)) {
            System.out.println("221 521");
        }
        if (this.getColor(2,1,2) == this.getColor(3,1,0)) {
            System.out.println("212 310");
        }



        if (this.getColor(3,2,1) == this.getColor(5,1,0)) {
            System.out.println("321 510");
        }
        if (this.getColor(3,1,2) == this.getColor(4,1,0)) {
            System.out.println("312 410");
        }



        if (this.getColor(4,2,1) == this.getColor(5,0,1)) {
            System.out.println("421 501");
        }


        System.out.println();
    }

    /**
     *  The debugCorner method prints to the console three cubics if they were
     *  found to be identical. This method was used in the early stages of
     *  development to help identify bugs in rotation methods. The bugs have
     *  since been fixed, but the method remains here for future reference.
     */
    public void debugCorner() {
        if (this.getColor(0,0,0) == this.getColor(2,0,2)
            || this.getColor(0,0,0) == this.getColor(3,0,0)
            || this.getColor(2,0,2) == this.getColor(3,0,0)) {
            System.out.println("000 202 300");
        }
        if (this.getColor(0,0,2) == this.getColor(1,0,2)
            || this.getColor(0,0,2) == this.getColor(2,0,0)
            || this.getColor(1,0,2) == this.getColor(2,0,0)) {
            System.out.println("002 102 200");
        }
        if (this.getColor(0,2,0) == this.getColor(3,0,2)
            || this.getColor(0,2,0) == this.getColor(4,0,0)
            || this.getColor(3,0,2) == this.getColor(4,0,0)) {
            System.out.println("020 302 400");
        }
        if (this.getColor(0,2,2) == this.getColor(4,0,2)
            || this.getColor(0,2,2) == this.getColor(1,0,0)
            || this.getColor(4,0,2) == this.getColor(1,0,0)) {
            System.out.println("022 402 100");
        }
        if (this.getColor(1,2,0) == this.getColor(4,2,2)
            || this.getColor(1,2,0) == this.getColor(5,0,2)
            || this.getColor(4,2,2) == this.getColor(5,0,2)) {
            System.out.println("120 422 502");
        }
        if (this.getColor(1,2,2) == this.getColor(5,2,2)
            || this.getColor(1,2,2) == this.getColor(2,2,0)
            || this.getColor(5,2,2) == this.getColor(2,2,0)) {
            System.out.println("122 522 220");
        }
        if (this.getColor(2,2,2) == this.getColor(5,2,0)
            || this.getColor(2,2,2) == this.getColor(3,2,0)
            || this.getColor(5,2,0) == this.getColor(3,2,0)) {
            System.out.println("222 520 320");
        }
        if (this.getColor(3,2,2) == this.getColor(5,0,0)
            || this.getColor(3,2,2) == this.getColor(4,2,0)
            || this.getColor(5,0,0) == this.getColor(4,2,0)) {
            System.out.println("322 500 420");
        }
        System.out.println();
    }
}