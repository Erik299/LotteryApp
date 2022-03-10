import { ComponentCustomProperties } from 'vue'
import { Store } from 'vuex'

declare module '@vue/runtime-core'{
    interface State{
        results: Array
    }

    interface ComponentCustomProperties {
        $store: Store<State>
    }
}