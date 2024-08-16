// wwwroot/js/kanban.js
window.initializeInteractJs = (dotNetHelper) => {
    interact('.kanban-card')
        .draggable({
            inertia: true,
            modifiers: [
                interact.modifiers.restrictRect({
                    restriction: 'parent',
                    endOnly: true
                })
            ],
            autoScroll: true,
            onmove: dragMoveListener,
            onend: function (event) {
                event.target.style.transform = 'translate(0px, 0px)';
                event.target.removeAttribute('data-x');
                event.target.removeAttribute('data-y');
            }
        });

    interact('.kanban-column')
        .dropzone({
            accept: '.kanban-card',
            ondrop: function (event) {
                event.preventDefault();
                event.stopPropagation();
                const cardId = event.relatedTarget.getAttribute('data-id');
                const newStatus = event.target.getAttribute('data-status');
                console.log(`Card ${cardId} dropped into ${newStatus}`);
                dotNetHelper.invokeMethodAsync('OnCardDropped', cardId, newStatus);
                event.relatedTarget.setAttribute('data-status', newStatus); // Update the status attribute
                event.target.appendChild(event.relatedTarget); // Move the card to the new column
            }
            
        });

    function dragMoveListener(event) {
        var target = event.target;
        var x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx;
        var y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

        target.style.transform = 'translate(' + x + 'px, ' + y + 'px)';

        target.setAttribute('data-x', x);
        target.setAttribute('data-y', y);
    }
};
