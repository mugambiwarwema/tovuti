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
  AttributeServiceProxy,
  AttributeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-attribute-dialog.component.html'
})
export class EditAttributeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  attribute: AttributeDto = new AttributeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _attributeService: AttributeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._attributeService.get(this.id).subscribe((result: AttributeDto) => {
      this.attribute = result;
    });
  }

  save(): void {
    this.saving = true;

    this._attributeService.update(this.attribute).subscribe(
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
