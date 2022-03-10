import Lottery from './Lottery'

const install = function (Vue, opts = {}) {
    Vue.component(Lottery.name, Lottery)
}

Lottery.install = install

export default Lottery