function GetModal() {
    return "<!-- Button trigger modal --> \
            <button type='button' style='display:none' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#modalCenter' id='modalAlert'></button> \
            <!-- Modal --> \
            <div class='modal fade' id='modalCenter' tabindex='-1' aria-hidden='true'> \
            <div class='modal-dialog modal-dialog-centered' role='document'> \
                <div class='modal-content'> \
                <div class='modal-header'> \
                    <h5 class='modal-title' id='modalCenterTitle'>TITLE_MODAL</h5> \
                    <button type='button'  class='btn-close' id='btnFechar' data-bs-dismiss='modal' aria-label='Close'></button> \
                </div> \
                <div class='modal-body' style='padding:0 !important'> \
                    <div class='row'> \
                    <div class='col mb-3' style='text-align:center'> \
                        SVG_ICON \
                    </div> \
                    </div> \
                <div style='text-align:center'><label>MSG_ALERT</label></div> \
                <br > \
                <div class='modal-footer' style='justify-content:center' > \
                    <button type='button' data-bs-dismiss='modal' class='btn btn-primary'>OK</button> \
                </div> \
                </div> \
            </div> \
            </div> \
        </div>";
}


function addSuccess(success) {
    if (success != null && success != "") {
        $("button[id='btnFechar']").click();
        $('#alertsModal').html("");
        var modal = GetModal().replace("TITLE_MODAL", "Atenção!");
        modal = modal.replace("SVG_ICON", IconSuccess());
        modal = modal.replace("MSG_ALERT", success);

        $('#alertsModal').html(modal);
        $('#modalAlert').click();
        $('html, body').scrollTop(0);
    }
}

function addError(error) {
    if (error != null && error != "") {
        $("button[id='btnFechar']").click();
        $('#alertsModal').html("");
        var modal = GetModal().replace("TITLE_MODAL", "Atenção!");
        modal = modal.replace("SVG_ICON", IconError());
        modal = modal.replace("MSG_ALERT", error);


        $('#alertsModal').html(modal);
        $('#modalAlert').click();
        $('html, body').scrollTop(0);
    }
}

function addWarning(warning) {
    if (warning != null && warning != "") {
        $("button[id='btnFechar']").click();
        $('#alertsModal').html("");
        var modal = GetModal().replace("TITLE_MODAL", "Atenção!");
        modal = modal.replace("SVG_ICON", IconWarning());
        modal = modal.replace("MSG_ALERT", warning);


        $('#alertsModal').html(modal);
        $('#modalAlert').click();
        $('html, body').scrollTop(0);
    }
}
function IconSuccess() {
    return "<div class='svg-box'> \
                <svg class='circular green-stroke'> \
                    <circle class='path' cx='75' cy='75' r='50' fill='none' stroke-width='5' stroke-miterlimit='10'/> \
                </svg> \
                <svg class='checkmark green-stroke'> \
                    <g transform='matrix(0.79961,8.65821e-32,8.39584e-32,0.79961,-489.57,-205.679)'> \
                        <path class='checkmark__check' fill='none' d='M616.306,283.025L634.087,300.805L673.361,261.53'/> \
                    </g> \
                </svg> \
            </div> ";
}

function IconWarning() {
    return "<div class='svg-box'> \
                <svg class='circular yellow-stroke'> \
                    <circle class='path' cx='75' cy='75' r='50' fill='none' stroke-width='5' stroke-miterlimit='10'/> \
                </svg> \
                <svg class='alert-sign yellow-stroke'> \
                    <g transform='matrix(1,0,0,1,-615.516,-257.346)'> \
                        <g transform='matrix(0.56541,-0.56541,0.56541,0.56541,93.7153,495.69)'> \
                            <path class='line' d='M634.087,300.805L673.361,261.53' fill='none'/> \
                        </g> \
                        <g transform='matrix(2.27612,-2.46519e-32,0,2.27612,-792.339,-404.147)'> \
                            <circle class='dot' cx='621.52' cy='316.126' r='1.318' /> \
                        </g> \
                    </g> \
                </svg> \
            </div> ";
}


function IconError() {
    return "<div class='svg-box'> \
                <svg class='circular red-stroke'> \
                    <circle class='path' cx='75' cy='75' r='50' fill='none' stroke-width='5' stroke-miterlimit='10'/> \
                </svg> \
                <svg class='cross red-stroke'> \
                    <g transform='matrix(0.79961,8.65821e-32,8.39584e-32,0.79961,-502.652,-204.518)'> \
                        <path class='first-line' d='M634.087,300.805L673.361,261.53' fill='none'/> \
                    </g> \
                    <g transform='matrix(-1.28587e-16,-0.79961,0.79961,-1.28587e-16,-204.752,543.031)'> \
                        <path class='second-line' d='M634.087,300.805L673.361,261.53'/> \
                    </g> \
                </svg> \
            </div> ";
}