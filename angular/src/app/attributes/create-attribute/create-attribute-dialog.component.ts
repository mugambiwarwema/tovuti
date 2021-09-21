import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  InputAttributeDto,
  AttributeServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-attribute-dialog.component.html'
})
export class CreateAttributeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  attribute: InputAttributeDto = new InputAttributeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _attributeService: AttributeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._attributeService.create(this.attribute).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
