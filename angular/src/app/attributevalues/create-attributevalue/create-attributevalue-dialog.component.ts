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
  InputAttributeValueDto,
  AttributeValueServiceProxy,
  AttributeServiceProxy,
  AttributeDto,
  AttributeDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: 'create-attributevalue-dialog.component.html'
})
export class CreateAttributeValueDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  attributevalue: InputAttributeValueDto = new InputAttributeValueDto();
  attributes: AttributeDto[] = []

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _attributevalueService: AttributeValueServiceProxy,
    public _attributeService: AttributeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAttributeList()
  }

  getAttributeList(): void {
    this._attributeService
      .getAll( "", 0, 100)
      .pipe( finalize(() => {}))
      .subscribe((result: AttributeDtoPagedResultDto) => { this.attributes = result.items;});
  }

  save(): void {
    this.saving = true;

    this._attributevalueService.create(this.attributevalue).subscribe(
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
