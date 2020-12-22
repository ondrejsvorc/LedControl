# LedControl

Programme with nice graphical interface that lets users to turn on and turn off a LED diode.
 
![](https://github.com/ondrejsvorc/LedControl/blob/main/LedControl/gui.png)

## Download [here](http://www.mediafire.com/file/xuk95tj2tj26lbt/LedControl.rar/file).

# How to decide what resistor to use?

We can use **Ohm's Law** to determine that.

First of all, we look for our LED's **specifications** on the Internet. We have to find out the **maximum amount of amperes** (alternatively miliamperes) and the **highest voltage** the LED can receive without destroying itself. 

In my case, the LED can receive maximum of 0.02 A (0.02 mA) and **2.1 V**. Arduino UNO board can supply **3.3 V** - **5 V**.

All this information enables us to calculate the value of a resistor we must use.

## Formula

![](https://github.com/ondrejsvorc/LedControl/blob/main/LedControl/resistor_formula.jpg)


# Setup

1. Upload **led.ino** to your Arduino board.
2. Download and install the app.
3. Open the app.
4. Choose correct **Serial Port** and **Baud Rate**.

![](https://github.com/ondrejsvorc/LedControl/blob/main/LedControl/scheme.png)

