import { GoldenLayout } from './golden-layout.js';

export function InitRfMode(tgt, config) {
    const goldenLayout = new GoldenLayout(tgt);
    goldenLayout.resizeWithContainerAutomatically = true;
    goldenLayout.registerComponent('rf', container => {
        container.element.append(...document.querySelectorAll(container.state.query));
    });
    goldenLayout.loadLayout(config);
}