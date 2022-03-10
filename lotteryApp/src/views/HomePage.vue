<template>
  <ion-page>
    <ion-content :fullscreen="true">
      <div>
        <v-lottery
          :options="options"
          diameter="500px"
          :winner="winner"
        ></v-lottery>
      </div>
    </ion-content>
  </ion-page>
</template>

<style scoped>
.header {
  margin: 2px auto 8px auto;
  width: 50%;
  text-align: center;
  background-color: rgba(10, 255, 255, 0);
}

.title {
  font-size: 30px;
  font-weight: bold;
  margin: auto;
  background: rgba(10, 255, 255, 0.7);
  font-variant: small-caps;
  box-shadow: 
    rgba(50, 50, 93, 0.25) 0px 50px 100px -20px,
    rgba(0, 0, 0, 0.3) 0px 30px 60px -30px,
    rgba(10, 37, 64, 0.35) 0px -2px 6px 0px inset;
}
</style>
<script>
import VLottery from "./../Lottery/Lottery.vue";
import { IonContent, IonPage } from "@ionic/vue";
import Swal from "sweetalert2";
import axios from "axios";

export default {
  data() {
    return {
      options: {
        prizes: [],
        rotations: 6,
        rotatingTime: 5, // seconds
        startButtonText: "Pörgetés!",
        callback: this.callback,
        roll: this.rollFunction,
      },
      winner: null,
      chances: [],
      maxValue: 0,
      maxQuantity: 0,
      calcValues: [],
      calcQuantity: [],
    };
  },
  components: {
    IonContent,
    IonPage,
    VLottery,
  },
  created() {
    const valueSplit = localStorage.values.split(",").map(Number);
    const quantitySplit = localStorage.quantities.split(",").map(Number);

    for (let i = 0; i < valueSplit.length; i++) {
      this.maxValue += parseInt(valueSplit[i]);
      this.maxQuantity += parseInt(quantitySplit[i]);
    }

    quantitySplit.forEach((value, index) => {
      quantitySplit[index] *= 100 / this.maxQuantity;
    });
    valueSplit.forEach((value, index) => {
      valueSplit[index] /= this.maxValue / 100;
    });

    for (let i = 0; i < valueSplit.length; i++) {
      this.chances.push((quantitySplit[i] / valueSplit[i]) * 100);
    }

    console.log(this.chances);
    console.log(quantitySplit);
    console.log(valueSplit);
  },
  methods: {
    callback(winner) {
      Swal.fire({
        title: "Gratulálunk!",
        text: "Nyert egy " + winner.name,
        width: 400,
        padding: "1.5em",
        confirmButtonText: "Az fasza",
        confirmButtonColor: "#3085d6",
        background: "rgba(255,255,255, 1)",
        backdrop: `
          rgba(0, 0, 0, 0.7)
          no-repeat
        `,
        imageUrl: winner.picture,
        imageWidth: 140,
        imageHeight: 200,
      });
      const object = {
        quantity: winner.quantity - 1,
        name: winner.name,
        value: winner.value,
        picture: winner.picture,
      };
      axios
        .put(`http://localhost:5000/api/datas/?id=` + winner.id, object)
        .then((response) => {
          console.log(response);
        })
        .catch(function (error) {
          console.log(error.response.data);
        });
    },
    rollFunction() {
      let maxChance = 0;
      for (let i = 0; i < this.chances.length; i++) {
        maxChance += this.chances[i];
      }
      // Should retrieve winner from server
      let hit = Math.floor(Math.random() * maxChance);
      console.log(hit);
      let winner = this.prizeRange().findIndex(function (prize) {
        return hit <= prize.max && hit >= prize.min;
      });
      this.winner = winner;
    },
    prizeRange() {
      let range = [];
      for (let i = 0; i < this.chances.length; i++) {
        if (i > 0) {
          range.push({
            min: range[i - 1].max + 1,
            max: range[i - 1].max + this.chances[i],
          });
        } else if (i === this.chances.length - 1) {
          // last one
          range.push({
            min: range[i - 1].max + 1,
            max: this.chances[i],
          });
        } else {
          // first one
          range.push({
            min: 0,
            max: this.chances[i],
          });
        }
      }
      return range;
    },
  },
};
</script>
