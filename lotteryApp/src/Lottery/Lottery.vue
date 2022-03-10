<template>
  <div id="app">
    <div class="border">
      <div
        class="wheel"
        :style="{
          width: diameter,
          height: diameter,
        }"
      >
        <div class="wheel-container">
          <div class="wheel-start-container">
            <div class="wheel-arrow"></div>
            <div
              class="wheel-start-button"
              @click="
                roll();
                changeto;
              "
            >
              <div class="wheel-start-text">
                {{ startButtonText }}
              </div>
            </div>
          </div>
          <div class="wheel-background" :style="wheelRotation">
            <div class="prize-list split" :style="sliceOffsetTranform">
              <div
                class="prize-list prize-item-container"
                v-for="(result, index) in results"
                :key="index"
                :style="sliceRotation(index)"
              />
            </div>
            <div class="prize-list">
              <div
                class="prize-list prize-item-container"
                v-for="(result, index) in results"
                :key="index"
                :style="sliceRotation(index)"
              >
                <div class="prize-list prize-item" :style="slice">
                  <div class="prize-name">
                    {{ result.name }}
                  </div>
                  <div v-if="result.picture" class="prize-image">
                    <img
                      style="max-width: 50%; max-height: 50%"
                      :src="result.picture"
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
#app{
  border: 5px solid white;
  position: absolute;
  top: 0%;
  left: 0%;
  right: 0%;
  bottom: 0%;
  margin: auto;
  width: 1000px;
  height: 600px;
}

.wheel {
  position: absolute;
  border-radius: 50%;
  top: 0%;
  left: 0%;
  right: 0%;
  bottom: 0%;
  margin: auto;
  width: 100%;
  height: 100%;
  box-shadow: 0px 0px 15px 0px rgba(255, 154, 0, 1);
  color: whitesmoke;
  text-shadow: 0px 0px 13px white, 0 0 45px white, 0 0 40px white,
    0 0 35px white, 0 0 30px white, 0 0 15px #fff;
}

.wheel-container {
  position: absolute;
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: space-around;
  align-items: center;
  margin: auto;
}

.wheel-start-container {
  display: flex;
  justify-content: center;
  width: 20%;
  height: 20%;
  z-index: 2;
  margin: auto auto;
}

.wheel:before,
.wheel:after {
  display: flex;
  justify-content: space-around;
  border-radius: 50%;
  content: "";
  position: absolute;
  top: 0%;
  left: 0%;
  right: 0%;
  bottom: 0%;
  background: linear-gradient(
    45deg,
    red,
    red,
    rgba(255, 154, 0, 1),
    red,
    red,
    rgba(255, 154, 0, 1),
    red,
    red,
    rgba(255, 154, 0, 1),
    red,
    red,
    rgba(255, 154, 0, 1)
  );
  background-size: 400%;
  width: 500px;
  height: 500px;
  z-index: -1;
  animation: steam 20s linear infinite;
  animation-direction: alternate;
  animation-fill-mode: forwards;
}

@keyframes steam {
  0% {
    background-position: 0 0;
  }
  50% {
    background-position: 400% 0;
  }
  100% {
    background-position: 0 0;
  }
}

.wheel:after {
  filter: blur(50px);
}

.wheel-background {
  width: inherit;
  height: inherit;
  border-radius: 50%;
  filter: drop-shadow(0 0 5px rgba(0, 0, 0, 0.3));
  box-sizing: border-box;
  position: absolute;
  background: radial-gradient(
    circle,
    rgba(0, 0, 0, 0.65) 0%,
    rgba(255, 154, 0, 0.65) 30%,
    rgba(255, 154, 0, 0.65) 60%,
    rgba(0, 0, 0, 0.65) 90%
  );
}

.wheel-arrow {
  border-bottom: 90px solid black;
  border-left: 30px solid transparent;
  border-right: 30px solid transparent;
  position: absolute;
  transform: scaleX(0.6) translateY(-50px) scaleY(1.2);
  filter: drop-shadow(5px 5px 5px rgba(0, 0, 0, 0.65));
}

.wheel-start-text {
  position: absolute;
  width: 100%;
  top: 36%;
  font-size: 22px;
  z-index: 2;
}

.wheel-start-button {
  user-select: none;
  border-radius: 50%;
  width: 100%;
  filter: drop-shadow(0 0 5px rgba(0, 0, 0, 0.65));
  background: red;
  transition: background-color 0.5s linear;
  text-align: center;
  color: whitesmoke;
  box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px, rgb(0, 0, 0) 0px 0px 0px 3px;
}

.wheel-start-button:hover {
  cursor: pointer;
}

.wheel-start-button:before {
  content: "";
  display: block;
  padding: 50%;
  position: absolute;
  border-radius: inherit;
  background:red;
  transition: all 0.5s;
}

.wheel-start-button:hover:before {
  opacity: 0;
  background-color: radial-gradient(white, white, white);
}

.wheel-start-button:after {
  content: "";
  border-radius: 50%;
  display: block;
  position: absolute;
  padding: 50%;
  background: white;
  transition: all 2s;
  opacity: 0;
}

.wheel-start-button:active:after {
  opacity: 1;
  transition: 0s;
}

.prize-list {
  width: 100%;
  height: 100%;
  position: absolute;
  z-index: 1;
}

.prize-item-container {
  display: flex;
  justify-content: space-around;
  margin: auto auto;
}

.prize-name {
  font-size: 30px;
  text-align: center;
}

.prize-item {
  height: 50%;
  margin: auto;
  padding-top: 20px;
}

.prize-image {
  display: block;
  position: relative;
  text-align: center;
  margin: auto;
  width: 75%;
}

.split > .prize-item-container:before {
  position: absolute;
  content: "";
  height: 50%;
  -webkit-font-smoothing: none;
}
</style>
<script>
import axios from "axios";

export default {
  name: "VLottery",
  props: {
    options: {},
    diameter: {
      required: false,
      default: "400px",
      type: String,
    },
    winner: {
      required: true,
    },
    datas: {
      type: Array,
    },
  },
  data() {
    return {
      startRotatingDegree: 0,
      rotateAngle: 0,
      disabled: true,
      results: JSON.parse(localStorage.getItem("resuls") || "[]"),
      values: localStorage.getItem("value") || "[]",
      quantities: localStorage.getItem("quantities") || "[]",
    };
  },

  created() {
    axios
      .get("http://localhost:5000/api/datas")
      .then((response) => {
        (this.results = response.data),
          console.log(this.results),
          console.log(response.data[1].name);
        localStorage.setItem("result", JSON.stringify(this.results));
      })
      .then((res) => {
        for (let i = 0; i < this.results.length; i++) {
          if (this.results[i].quantity <= 0) {
            this.results.splice(i);
          }
        }
        this.values = [];
        this.quantities = [];
        for (let i = 0; i < this.results.length; i++) {
          this.values.push(this.results[i].value);
          this.quantities.push(this.results[i].quantity);
        }
        localStorage.setItem("values", this.values);
        localStorage.setItem("quantities", this.quantities);
      });
  },
  methods: {
    roll() {
      if (!this.disabled) return;
      this.options.roll();
    },
    rotating(winner) {
      if (!this.disabled) return;
      this.sendResult(winner);
      let resultIndex = winner; // Last piece
      this.disabled = false; // disable lottery
      // roll
      let rotateAngle =
        this.startRotatingDegree +
        this.rotations * 360 +
        this.resultAngles[resultIndex] -
        (this.startRotatingDegree % 360);

      this.startRotatingDegree = rotateAngle;
      this.rotateAngle = "rotate(" + rotateAngle + "deg)";

      setTimeout(() => {
        this.disabled = true;
        this.gameOver(winner);
      }, this.rotatingTime * 1000 + 255);
    },
    gameOver(winner) {
      this.options.callback(this.results[winner]);
    },
    sendResult(winner) {
      // send to back end
      console.log(winner);
    },
    sliceRotation(index) {
      const rotateAngle = index * this.sliceAngle + this.sliceOffset;
      return { transform: `rotate(${rotateAngle}deg)` };
    },
    reset() {
      // TODO: reset wheel
      // let rotateAngle =
      //   this.startRotatingDegree +
      //   this.rotations * 360 +
      //   this.resultAngles[0] -
      //   this.startRotatingDegree % 360;
      // this.startRotatingDegree = rotateAngle;
      // this.rotateAngle = "rotate(" + rotateAngle + "deg)";
    },
  },
  computed: {
    prizeList() {
      return (this.options && this.results) || [];
    },
    rotations() {
      return this.options.rotations || 1;
    },
    resultAngles() {
      let angles = [];
      for (let index = 0; index < this.results.length; index++) {
        angles.push(360 - this.sliceOffset - this.sliceAngle * index);
      }
      return angles;
    },
    rotatingTime() {
      return (
        (Number.isInteger(this.options.rotatingTime) &&
          this.options.rotatingTime) ||
        5
      );
    },
    rotateTransition() {
      return `transform ${this.options.rotatingTime}s ease-in-out`;
    },
    sliceAngle() {
      return this.results.length > 0 ? 360 / this.results.length : 0;
    },
    sliceOffset() {
      return this.sliceAngle / 2;
    },
    startButtonText() {
      return this.options.startButtonText || "Start";
    },
    wheelRotation() {
      return {
        transform: this.rotateAngle,
        transition: this.rotateTransition,
      };
    },
    sliceOffsetTranform() {
      return {
        transform: `rotate(${this.sliceOffset}deg)`,
      };
    },
    slice() {
      return {
        width: `calc(100% * ${Math.PI} / ${this.results.length})`,
      };
    },
  },
  components: {},
  watch: {
    winner(winner) {
      if (winner !== null && winner !== undefined) {
        this.rotating(winner);
      } else {
        this.reset();
      }
    },
  },
};
</script>
