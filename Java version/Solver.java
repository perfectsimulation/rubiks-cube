/**
 *  The Solver class calls on methods from the Cube class in the proper order
 *  to solve a Rubik's Cube (RC). It prints to the console the Cube at each
 *  stage of the solution.
 */

public class Solver {
	public static void main(String[] args) {
		Cube cube = new Cube();
		cube.printCube();

//	STAGE 1.1
//	LAYER 1: WHITE CROSS

		boolean cross;
		cross = false;
		while (!cross) {
			int w_r;
			int w_b;
			int w_o;
			int w_g;
			int r_w;
			int b_w;
			int o_w;
			int g_w;
			w_r = cube.getColor(0, 1, 2);
			w_b = cube.getColor(0, 0, 1);
			w_o = cube.getColor(0, 1, 0);
			w_g = cube.getColor(0, 2, 1);
			r_w = cube.getColor(1, 0, 1);
			b_w = cube.getColor(2, 0, 1);
			o_w = cube.getColor(3, 0, 1);
			g_w = cube.getColor(4, 0, 1);
			boolean isR;
			boolean isB;
			boolean isO;
			boolean isG;
			isR = false;
			isB = false;
			isO = false;
			isG = false;


			//  This while loop searches the Cube for the edge piece
			//  (white + red). Once the correct edge is found, methods from
			//  the Cube class are called to apply the correct algorithm.
			while (w_r != 0 || r_w != 1 || !isR) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 0 && !isR) {
						isR = cube.isRightEdge(i, 0, 1, 1);
						if (isR) {
							cube.crossRed(i, 0, 1);
							w_r = cube.getColor(0, 1, 2);
							r_w = cube.getColor(1, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 0) == 0 && !isR) {
						isR = cube.isRightEdge(i, 1, 0, 1);
						if (isR) {
							cube.crossRed(i, 1, 0);
							w_r = cube.getColor(0, 1, 2);
							r_w = cube.getColor(1, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 2) == 0 && !isR) {
						isR = cube.isRightEdge(i, 1, 2, 1);
						if (isR) {
							cube.crossRed(i, 1, 2);
							w_r = cube.getColor(0, 1, 2);
							r_w = cube.getColor(1, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 2, 1) == 0 && !isR) {
						isR = cube.isRightEdge(i, 2, 1, 1);
						if (isR) {
							cube.crossRed(i, 2, 1);
							w_r = cube.getColor(0, 1, 2);
							r_w = cube.getColor(1, 0, 1);
							cross = cube.crossed();
						}
					} else {}
				}
				cross = cube.crossed();
			}


			//  This while loop searches the Cube for the edge piece
			//  (white + blue). Once the correct edge is found, methods from
			//  the Cube class are called to apply the correct algorithm.
			while (w_b != 0 || b_w != 2 || !isB) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 0 && !isB) {
						isB = cube.isRightEdge(i, 0, 1, 2);
						if (isB) {
							cube.crossBlue(i, 0, 1);
							w_b = cube.getColor(0, 0, 1);
							b_w = cube.getColor(2, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 0) == 0 && !isB) {
						isB = cube.isRightEdge(i, 1, 0, 2);
						if (isB) {
							cube.crossBlue(i, 1, 0);
							w_b = cube.getColor(0, 0, 1);
							b_w = cube.getColor(2, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 2) == 0 && !isB) {
						isB = cube.isRightEdge(i, 1, 2, 2);
						if (isB) {
							cube.crossBlue(i, 1, 2);
							w_b = cube.getColor(0, 0, 1);
							b_w = cube.getColor(2, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 2, 1) == 0 && !isB) {
						isB = cube.isRightEdge(i, 2, 1, 2);
						if (isB) {
							cube.crossBlue(i, 2, 1);
							w_b = cube.getColor(0, 0, 1);
							b_w = cube.getColor(2, 0, 1);
							cross = cube.crossed();
						}
					} else {}
				}
				cross = cube.crossed();
			}

			//  Check to make sure the algorithm worked properly and did not
			//  displace any cubics that are correctly placed.
			w_r = cube.getColor(0, 1, 2);
			r_w = cube.getColor(1, 0, 1);
			if (w_r != 0 || r_w != 1) {
				isR = false;
			}


			//  This while loop searches the Cube for the edge piece
			//  (white + orange). Once the correct edge is found, methods from
			//  the Cube class are called to apply the correct algorithm.
			while (w_o != 0 || o_w != 3 || !isO) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 0 && !isO) {
						isO = cube.isRightEdge(i, 0, 1, 3);
						if (isO) {
							cube.crossOrange(i, 0, 1);
							w_o = cube.getColor(0, 1, 0);
							o_w = cube.getColor(3, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 0) == 0 && !isO) {
						isO = cube.isRightEdge(i, 1, 0, 3);
						if (isO) {
							cube.crossOrange(i, 1, 0);
							w_o = cube.getColor(0, 1, 0);
							o_w = cube.getColor(3, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 2) == 0 && !isO) {
						isO = cube.isRightEdge(i, 1, 2, 3);
						if (isO) {
							cube.crossOrange(i, 1, 2);
							w_o = cube.getColor(0, 1, 0);
							o_w = cube.getColor(3, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 2, 1) == 0 && !isO) {
						isO = cube.isRightEdge(i, 2, 1, 3);
						if (isO) {
							cube.crossOrange(i, 2, 1);
							w_o = cube.getColor(0, 1, 0);
							o_w = cube.getColor(3, 0, 1);
							cross = cube.crossed();
						}
					} else {}
				}
				cross = cube.crossed();
			}

			//  Check to make sure the algorithm worked properly and did not
			//  displace any cubics that are correctly placed.
			w_r = cube.getColor(0, 1, 2);
			r_w = cube.getColor(1, 0, 1);
			if (w_r != 0 || r_w != 1) {
				isR = false;
				isB = false;
			}
			w_b = cube.getColor(0, 0, 1);
			b_w = cube.getColor(2, 0, 1);
			if (w_b != 0 || b_w != 2) {
				isR = false;
				isB = false;
			}


			//  This while loop searches the Cube for the edge piece
			//  (white + green). Once the correct edge is found, methods from
			//  the Cube class are called to apply the correct algorithm.
			while (w_g != 0 || g_w != 4 || !isG) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 0 && !isG) {
						isG = cube.isRightEdge(i, 0, 1, 4);
						if (isG) {
							cube.crossGreen(i, 0, 1);
							w_g = cube.getColor(0, 2, 1);
							g_w = cube.getColor(4, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 0) == 0 && !isG) {
						isG = cube.isRightEdge(i, 1, 0, 4);
						if (isG) {
							cube.crossGreen(i, 1, 0);
							w_g = cube.getColor(0, 2, 1);
							g_w = cube.getColor(4, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 1, 2) == 0 && !isG) {
						isG = cube.isRightEdge(i, 1, 2, 4);
						if (isG) {
							cube.crossGreen(i, 1, 2);
							w_g = cube.getColor(0, 2, 1);
							g_w = cube.getColor(4, 0, 1);
							cross = cube.crossed();
						}
					} if (cube.getColor(i, 2, 1) == 0 && !isG) {
						isG = cube.isRightEdge(i, 2, 1, 4);
						if (isG) {
							cube.crossGreen(i, 2, 1);
							w_g = cube.getColor(0, 2, 1);
							g_w = cube.getColor(4, 0, 1);
							cross = cube.crossed();
						}
					} else {}
				}
				cross = cube.crossed();
			}

			//  Check to make sure the algorithm worked properly and did not
			//  displace any cubics that are correctly placed.
			w_r = cube.getColor(0, 1, 2);
			r_w = cube.getColor(1, 0, 1);
			if (w_r != 0 || r_w != 1) {
				isR = false;
				isB = false;
				isO = false;
			}
			w_b = cube.getColor(0, 0, 1);
			b_w = cube.getColor(2, 0, 1);
			if (w_b != 0 || b_w != 2) {
				isR = false;
				isB = false;
				isO = false;
			}
			w_o = cube.getColor(0, 1, 0);
			o_w = cube.getColor(3, 0, 1);
			if (w_o != 0 || o_w != 3) {
				isR = false;
				isB = false;
				isO = false;
			}
		}
		cube.printCube();

//	STAGE 1.2
//	LAYER 1: WHITE CORNERS

		boolean corners;
		corners = false;
		while (!corners) {
			int r_b;
			int b_o;
			int o_g;
			int g_r;
			int b_r;
			int o_b;
			int g_o;
			int r_g;
			int r_w;
			int b_w;
			int o_w;
			int g_w;
			r_w = cube.getColor(0, 0, 2);
			b_w = cube.getColor(0, 0, 0);
			o_w = cube.getColor(0, 2, 0);
			g_w = cube.getColor(0, 2, 2);
			r_b = cube.getColor(1, 0, 2);
			b_o = cube.getColor(2, 0, 2);
			o_g = cube.getColor(3, 0, 2);
			g_r = cube.getColor(4, 0, 2);
			b_r = cube.getColor(2, 0, 0);
			o_b = cube.getColor(3, 0, 0);
			g_o = cube.getColor(4, 0, 0);
			r_g = cube.getColor(1, 0, 0);
			boolean isR;
			boolean isB;
			boolean isO;
			boolean isG;
			isR = false;
			isB = false;
			isO = false;
			isG = false;


			//  This while loop searches the Cube for the corner piece
			//  (white + red + blue). Once the correct corner is found, methods
			//  from the Cube class are called to apply the correct algorithm.
			while (r_b != 1 || b_r != 2 || r_w != 0 || !isR) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 0) == 1 && !isR) {
						isR = cube.isRightCorner(i, 0, 0, 2);
						if (isR) {
							cube.cornerRed(i, 0, 0);
							r_w = cube.getColor(0, 0, 2);
							r_b = cube.getColor(1, 0, 2);
							b_r = cube.getColor(2, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 0, 2) == 1 && !isR) {
						isR = cube.isRightCorner(i, 0, 2, 2);
						if (isR) {
							cube.cornerRed(i, 0, 2);
							r_w = cube.getColor(0, 0, 2);
							r_b = cube.getColor(1, 0, 2);
							b_r = cube.getColor(2, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 0) == 1 && !isR) {
						isR = cube.isRightCorner(i, 2, 0, 2);
						if (isR) {
							cube.cornerRed(i, 2, 0);
							r_w = cube.getColor(0, 0, 2);
							r_b = cube.getColor(1, 0, 2);
							b_r = cube.getColor(2, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 2) == 1 && !isR) {
						isR = cube.isRightCorner(i, 2, 2, 2);
						if (isR) {
							cube.cornerRed(i, 2, 2);
							r_w = cube.getColor(0, 0, 2);
							r_b = cube.getColor(1, 0, 2);
							b_r = cube.getColor(2, 0, 0);
							corners = cube.cornered();
						}
					} else {}
				}
				corners = cube.cornered();
			}


			//  This while loop searches the Cube for the corner piece
			//  (white + blue + orange). Once the correct corner is found,
			//  methods from the Cube class are called to apply the correct
			//  algorithm.
			while (b_o != 2 || o_b != 3 || b_w != 0 || !isB) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 0) == 2 && !isB) {
						isB = cube.isRightCorner(i, 0, 0, 3);
						if (isB) {
							cube.cornerBlue(i, 0, 0);
							b_w = cube.getColor(0, 0, 0);
							b_o = cube.getColor(2, 0, 2);
							o_b = cube.getColor(3, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 0, 2) == 2 && !isB) {
						isB = cube.isRightCorner(i, 0, 2, 3);
						if (isB) {
							cube.cornerBlue(i, 0, 2);
							b_w = cube.getColor(0, 0, 0);
							b_o = cube.getColor(2, 0, 2);
							o_b = cube.getColor(3, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 0) == 2 && !isB) {
						isB = cube.isRightCorner(i, 2, 0, 3);
						if (isB) {
							cube.cornerBlue(i, 2, 0);
							b_w = cube.getColor(0, 0, 0);
							b_o = cube.getColor(2, 0, 2);
							o_b = cube.getColor(3, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 2) == 2 && !isB) {
						isB = cube.isRightCorner(i, 2, 2, 3);
						if (isB) {
							cube.cornerBlue(i, 2, 2);
							b_w = cube.getColor(0, 0, 0);
							b_o = cube.getColor(2, 0, 2);
							o_b = cube.getColor(3, 0, 0);
							corners = cube.cornered();
						}
					} else {}
				}
				corners = cube.cornered();
			}

			//  Check to make sure the algorithm worked properly and did not
			//  displace any cubics that are correctly placed.
			r_w = cube.getColor(0, 0, 2);
			r_b = cube.getColor(1, 0, 2);
			b_r = cube.getColor(2, 0, 0);
			if (r_b != 1 || b_r != 2 || r_w != 0) {
				isR = false;
			}


			//  This while loop searches the Cube for the corner piece
			//  (white + orange + green). Once the correct corner is found,
			//  methods from the Cube class are called to apply the correct
			//  algorithm.
			while (o_g != 3 || g_o != 4 || o_w != 0 || !isO) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 0) == 3 && !isO) {
						isO = cube.isRightCorner(i, 0, 0, 4);
						if (isO) {
							cube.cornerOrange(i, 0, 0);
							o_w = cube.getColor(0, 2, 0);
							o_g = cube.getColor(3, 0, 2);
							g_o = cube.getColor(4, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 0, 2) == 3 && !isO) {
						isO = cube.isRightCorner(i, 0, 2, 4);
						if (isO) {
							cube.cornerOrange(i, 0, 2);
							o_w = cube.getColor(0, 2, 0);
							o_g = cube.getColor(3, 0, 2);
							g_o = cube.getColor(4, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 0) == 3 && !isO) {
						isO = cube.isRightCorner(i, 2, 0, 4);
						if (isO) {
							cube.cornerOrange(i, 2, 0);
							o_w = cube.getColor(0, 2, 0);
							o_g = cube.getColor(3, 0, 2);
							g_o = cube.getColor(4, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 2) == 3 && !isO) {
						isO = cube.isRightCorner(i, 2, 2, 4);
						if (isO) {
							cube.cornerOrange(i, 2, 2);
							o_w = cube.getColor(0, 2, 0);
							o_g = cube.getColor(3, 0, 2);
							g_o = cube.getColor(4, 0, 0);
							corners = cube.cornered();
						}
					} else {}
				}
				corners = cube.cornered();
			}

			//  Check to make sure the algorithm worked properly and did not
			//  displace any cubics that are correctly placed.
			r_w = cube.getColor(0, 0, 2);
			r_b = cube.getColor(1, 0, 2);
			b_r = cube.getColor(2, 0, 0);
			if (r_b != 1 || b_r != 2 || r_w != 0) {
				isR = false;
				isB = false;
			}
			b_w = cube.getColor(0, 0, 0);
			b_o = cube.getColor(2, 0, 2);
			o_b = cube.getColor(3, 0, 0);
			if (b_o != 2 || o_b != 3 || o_w != 0) {
				isR = false;
				isB = false;
			}


			//  This while loop searches the Cube for the corner piece
			//  (white + green + red). Once the correct corner is found,
			//  methods from the Cube class are called to apply the correct
			//  algorithm.
			while (g_r != 4 || r_g != 1 || g_w != 0 || !isG) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 0) == 4 && !isG) {
						isG = cube.isRightCorner(i, 0, 0, 1);
						if (isG) {
							cube.cornerGreen(i, 0, 0);
							g_w = cube.getColor(0, 2, 2);
							g_r = cube.getColor(4, 0, 2);
							r_g = cube.getColor(1, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 0, 2) == 4 && !isG) {
						isG = cube.isRightCorner(i, 0, 2, 1);
						if (isG) {
							cube.cornerGreen(i, 0, 2);
							g_w = cube.getColor(0, 2, 2);
							g_r = cube.getColor(4, 0, 2);
							r_g = cube.getColor(1, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 0) == 4 && !isG) {
						isG = cube.isRightCorner(i, 2, 0, 1);
						if (isG) {
							cube.cornerGreen(i, 2, 0);
							g_w = cube.getColor(0, 2, 2);
							g_r = cube.getColor(4, 0, 2);
							r_g = cube.getColor(1, 0, 0);
							corners = cube.cornered();
						}
					} if (cube.getColor(i, 2, 2) == 4 && !isG) {
						isG = cube.isRightCorner(i, 2, 2, 1);
						if (isG) {
							cube.cornerGreen(i, 2, 2);
							g_w = cube.getColor(0, 2, 2);
							g_r = cube.getColor(4, 0, 2);
							r_g = cube.getColor(1, 0, 0);
							corners = cube.cornered();
						}
					} else {}
				}
				corners = cube.cornered();
			}

			//  Check to make sure the algorithm worked properly and did not
			//  displace any cubics that are correctly placed.
			r_w = cube.getColor(0, 0, 2);
			r_b = cube.getColor(1, 0, 2);
			b_r = cube.getColor(2, 0, 0);
			if (r_b != 1 || b_r != 2 || r_w != 0) {
				isR = false;
				isB = false;
				isO = false;
			}
			b_w = cube.getColor(0, 0, 0);
			b_o = cube.getColor(2, 0, 2);
			o_b = cube.getColor(3, 0, 0);
			if (b_o != 2 || o_b != 3 || b_w != 0) {
				isR = false;
				isB = false;
				isO = false;
			}
			o_w = cube.getColor(0, 2, 0);
			o_g = cube.getColor(3, 0, 2);
			g_o = cube.getColor(4, 0, 0);
			if (o_g != 3 || g_o != 4 || o_w != 0) {
				isR = false;
				isB = false;
				isO = false;
			}
		}
		cube.printCube();

//	STAGE 2
//	LAYER 2

		boolean lay2Rest;
		lay2Rest = false;
		while (!lay2Rest) {
			int r_b;
			int b_o;
			int o_g;
			int g_r;
			int b_r;
			int o_b;
			int g_o;
			int r_g;
			r_b = cube.getColor(1, 1, 2);
			b_o = cube.getColor(2, 1, 2);
			o_g = cube.getColor(3, 1, 2);
			g_r = cube.getColor(4, 1, 2);
			b_r = cube.getColor(2, 1, 0);
			o_b = cube.getColor(3, 1, 0);
			g_o = cube.getColor(4, 1, 0);
			r_g = cube.getColor(1, 1, 0);
			boolean isR;
			boolean isB;
			boolean isO;
			boolean isG;
			isR = false;
			isB = false;
			isO = false;
			isG = false;


			//  This while loop searches the Cube for the edge piece
			//  (red + blue). Once the correct edge is found, methods
			//  from the Cube class are called to apply the correct algorithm.
			while (r_b != 1 || b_r != 2 || !isR) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 1 && !isR) {
						isR = cube.isRightEdge(i, 0, 1, 2);
						if (isR) {
							cube.lay2Red(i, 0, 1);
							r_b = cube.getColor(1, 1, 2);
							b_r = cube.getColor(2, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 2, 1) == 1 && !isR) {
						isR = cube.isRightEdge(i, 2, 1, 2);
						if (isR) {
							cube.lay2Red(i, 2, 1);
							r_b = cube.getColor(1, 1, 2);
							b_r = cube.getColor(2, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 0) == 1 && !isR) {
						isR = cube.isRightEdge(i, 1, 0, 2);
						if (isR) {
							cube.lay2Red(i, 1, 0);
							r_b = cube.getColor(1, 1, 2);
							b_r = cube.getColor(2, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 2) == 1 && !isR) {
						isR = cube.isRightEdge(i, 1, 2, 2);
						if (isR) {
							cube.lay2Red(i, 1, 2);
							r_b = cube.getColor(1, 1, 2);
							b_r = cube.getColor(2, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
				}
			}


			//  This while loop searches the Cube for the edge piece
			//  (blue + orange). Once the correct edge is found, methods
			//  from the Cube class are called to apply the correct algorithm.
			while (b_o != 2 || o_b != 3 || !isB) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 2 && !isB) {
						isB = cube.isRightEdge(i, 0, 1, 3);
						if (isB) {
							cube.lay2Blue(i, 0, 1);
							b_o = cube.getColor(2, 1, 2);
							o_b = cube.getColor(3, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 2, 1) == 2 && !isB) {
						isB = cube.isRightEdge(i, 2, 1, 3);
						if (isB) {
							cube.lay2Blue(i, 2, 1);
							b_o = cube.getColor(2, 1, 2);
							o_b = cube.getColor(3, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 0) == 2 && !isB) {
						isB = cube.isRightEdge(i, 1, 0, 3);
						if (isB) {
							cube.lay2Blue(i, 1, 0);
							b_o = cube.getColor(2, 1, 2);
							o_b = cube.getColor(3, 1, 0);
							lay2Rest = cube.lay2();

						}
					}
					if (cube.getColor(i, 1, 2) == 2 && !isB) {
						isB = cube.isRightEdge(i, 1, 2, 3);
						if (isB) {
							cube.lay2Blue(i, 1, 2);
							b_o = cube.getColor(2, 1, 2);
							o_b = cube.getColor(3, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
				}
			}


			//  This while loop searches the Cube for the edge piece
			//  (orange + green). Once the correct edge is found, methods
			//  from the Cube class are called to apply the correct algorithm.
			while (o_g != 3 || g_o != 4 || !isO) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 3 && !isO) {
						isO = cube.isRightEdge(i, 0, 1, 4);
						if (isO) {
							cube.lay2Orange(i, 0, 1);
							o_g = cube.getColor(3, 1, 2);
							g_o = cube.getColor(4, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 2, 1) == 3 && !isO) {
						isO = cube.isRightEdge(i, 2, 1, 4);
						if (isO) {
							cube.lay2Orange(i, 2, 1);
							o_g = cube.getColor(3, 1, 2);
							g_o = cube.getColor(4, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 0) == 3 && !isO) {
						isO = cube.isRightEdge(i, 1, 0, 4);
						if (isO) {
							cube.lay2Orange(i, 1, 0);
							o_g = cube.getColor(3, 1, 2);
							g_o = cube.getColor(4, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 2) == 3 && !isO) {
						isO = cube.isRightEdge(i, 1, 2, 4);
						if (isO) {
							cube.lay2Orange(i, 1, 2);
							o_g = cube.getColor(3, 1, 2);
							g_o = cube.getColor(4, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
				}
			}


			//  This while loop searches the Cube for the edge piece
			//  (green + red). Once the correct edge is found, methods
			//  from the Cube class are called to apply the correct algorithm.
			while (g_r != 4 || r_g != 1 || !isG) {
				for (int i = 0; i < 6; i++) {
					if (cube.getColor(i, 0, 1) == 4 && !isG) {
						isG = cube.isRightEdge(i, 0, 1, 1);
						if (isG) {
							cube.lay2Green(i, 0, 1);
							g_r = cube.getColor(4, 1, 2);
							r_g = cube.getColor(1, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 2, 1) == 4 && !isG) {
						isG = cube.isRightEdge(i, 2, 1, 1);
						if (isG) {
							cube.lay2Green(i, 2, 1);
							g_r = cube.getColor(4, 1, 2);
							r_g = cube.getColor(1, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 0) == 4 && !isG) {
						isG = cube.isRightEdge(i, 1, 0, 1);
						if (isG) {
							cube.lay2Green(i, 1, 0);
							g_r = cube.getColor(4, 1, 2);
							r_g = cube.getColor(1, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
					if (cube.getColor(i, 1, 2) == 4 && !isG) {
						isG = cube.isRightEdge(i, 1, 2, 1);
						if (isG) {
							cube.lay2Green(i, 1, 2);
							g_r = cube.getColor(4, 1, 2);
							r_g = cube.getColor(1, 1, 0);
							lay2Rest = cube.lay2();
						}
					}
				}
			}
		}
		cube.printCube();


//	The last layer of the Rubik's Cube solver is unfinished.s

//	STAGE 3
//	LAYER 3

		// boolean yellow;
		// yellow = false;
		// while (!yellow) {
		// 	int y00;
		// 	int y01;
		// 	int y02;
		// 	int y10;
		// 	int y11;
		// 	int y12;
		// 	int y20;
		// 	int y21;
		// 	int y22;
		// 	y00 = cube.getColor(5, 0, 0);
		// 	y01 = cube.getColor(5, 0, 1);
		// 	y02 = cube.getColor(5, 0, 2);
		// 	y10 = cube.getColor(5, 1, 0);
		// 	y11 = cube.getColor(5, 1, 1);
		// 	y12 = cube.getColor(5, 1, 2);
		// 	y20 = cube.getColor(5, 2, 0);
		// 	y21 = cube.getColor(5, 2, 1);
		// 	y22 = cube.getColor(5, 2, 2);

		// 	if (y01 != 5 && y21 != 5 && y10 != 5 && y12 != 5) {
		// 		cube.horz();
		// 	} else if (y01 != 5 && y21 != 5 && y10 == 5 && y12 == 5) {
		// 		cube.horz();
		// 	} else if (y01 == 5 && y21 == 5 && y10 != 5 && y12 != 5) {
		// 		cube.vert();
		// 	} else if (y01 == 5 && y21 == 5 && y10 == 5 && y12 == 5) {
		// 		cube.vert();
		// 	} else if (y01 == 5 && y21 == 5 && y10 == 5 && y12 == 5) {
		// 		cube.l(1);
		// 	} else if (y01 == 5 && y21 == 5 && y10 == 5 && y12 == 5) {
		// 		cube.l(2);
		// 	} else if (y01 == 5 && y21 == 5 && y10 == 5 && y12 == 5) {
		// 		cube.l(3);
		// 	} else if (y01 == 5 && y21 == 5 && y10 == 5 && y12 == 5) {
		// 		cube.l(4);
		// 	} else if (y00 == 5 && y01 == 5 && y10 == 5 && y12 == 5
		// 		&& y21 == 5) {
		// 		if (y02 == 5) {
		// 			cube.fish(1);
		// 		}
		// 		if (y02 != 5) {
		// 			cube.fish(1);
		// 		}
		// 	} else if (y01 == 5 && y02 == 5 && y10 == 5 && y12 == 5
		// 		&& y21 == 5) {
		// 		if (y00 == 5) {
		// 			cube.fish(2);
		// 		}
		// 		if (y00 != 5) {
		// 			cube.fish(2);
		// 		}
		// 	} else if (y01 == 5 && y10 == 5 && y12 == 5 && y21 == 5
		// 		&& y22 == 5) {
		// 		if (y20 == 5) {
		// 			cube.fish(3);
		// 		}
		// 		if (y02 != 5) {
		// 			cube.fish(4);
		// 		}
		// 	} else if (y01 == 5 && y10 == 5 && y12 == 5 && y21 == 5
		// 		&& y20 == 5) {
		// 		if (y22 == 5) {
		// 			cube.fish(4);
		// 		}
		// 		if (y22 != 5) {
		// 			cube.fish(3);
		// 		}
		// 	} else {
		// 		cube.horz();
		// 	}
		// 	yellow = cube.yellowed();
		// 	cube.printCube();
		// }
	}
}